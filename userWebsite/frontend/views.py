# frontend/views.py
import pretty_errors
from django.shortcuts import render, get_object_or_404
from django.http import HttpResponse, HttpResponseBadRequest
from datetime import timedelta, datetime
from backend.models import CourtSection, Reservation, Court, Admin, Client, Review
import json
from datetime import date
import os
from PIL import Image
from django.shortcuts import redirect
import logging

logger = logging.getLogger(__name__)


def home_view(request):
    courtDetails = []
    courts = Court.objects.all()
    for court in courts:
        admin = Admin.objects.get(adminId=court.adminId.adminId)
        image_path = f"frontend/courtImages/{court.courtId}.jpeg"  # Adjusted path for static files
        courtDetails.append(
            (
                court.courtId,
                court.name,
                court.location,
                admin.username,
                admin.number,
                image_path,
            )
        )
    context = {"courtDetails": courtDetails}
    return render(request, "home.html", context)


def courtSectionView(request, courtId):
    courtSections = CourtSection.objects.filter(courtId=courtId)
    ids=[]
    for courtSection in courtSections:
        image_path = f"frontend/courtSectionsImages/{courtSection.courtSectionId}.jpeg"
        courtSection.image_path = (
            image_path  # Add image_path as an attribute to each object
        )
        ids.append(courtSection.courtSectionId);

    context = {
        "courtSections": courtSections,
        "ids":ids
    }
    return render(request, "court_section.html", context)


from django.views.decorators.http import require_http_methods, require_POST, require_GET
from django.views.decorators.csrf import csrf_exempt


# @csrf_exempt
@require_GET
def available_times(request):
    logger.info(f"Received {request.method} request from {request.META['REMOTE_ADDR']}")

    if request.method != "GET":
        return HttpResponseBadRequest("Invalid request method")

    try:
        courtSectionId = request.GET.get("courtSectionId")
        selected_date = request.GET.get("date")
        courtSectionId = int(courtSectionId)
        year, month, day = map(int, selected_date.split("-"))
        dateObj = date(year, month, day)
    except (ValueError, TypeError):
        return False

    court_section = CourtSection.objects.get(courtSectionId=courtSectionId)
    courtId=court_section.courtId
    if not (court_section.openTime and court_section.closeTime):
        return render(request, "home.html", {"context": {}})

    reservations = Reservation.objects.filter(
        courtsectionID=court_section, date=dateObj
    )

    reservations_data = sorted(
        [(reservation.startTime, reservation.endTime) for reservation in reservations],
        key=lambda x: x[0],
    )

    available_slots = []

    if not reservations_data:
        available_slots.append((court_section.openTime, court_section.closeTime))
    else:
        available_slots.append(
            (court_section.openTime, reservations_data[0][0])
            if reservations_data[0][0] > court_section.openTime
            else None
        )

        for i in range(len(reservations_data) - 1):
            if reservations_data[i][1] < reservations_data[i + 1][0]:
                available_slots.append(
                    (reservations_data[i][1], reservations_data[i + 1][0])
                )

        available_slots.append(
            (reservations_data[-1][1], court_section.closeTime)
            if reservations_data[-1][1] < court_section.closeTime
            else None
        )
        available_slots=[item for item in available_slots if item is not None]
        if(available_slots==[]):
            url = reverse("courtSectionView", kwargs={"courtId": courtId.courtId})

            return redirect(url)

    available_slots = [
        (
            f"{time_tuple[0].hour}:{time_tuple[0].minute}",
            f"{time_tuple[1].hour}:{time_tuple[1].minute}",
        )
        for time_tuple in available_slots
    ]
    context = {
        "court_section": {
            "courtSectionId": court_section.courtSectionId,
            "courtId": court_section.courtId.courtId,
            "sectionName": court_section.sectionName,
            "sectionType": court_section.sectionType,
            "fansCapacity": court_section.fansCapacity,
            "openTime": court_section.openTime.strftime("%H:%M:%S"),
            "closeTime": court_section.closeTime.strftime("%H:%M:%S"),
        },
        "date": dateObj.strftime("%Y-%m-%d"),  # Convert date to string
        "available_slots": available_slots,
    }

    request.session["reservation_context"] = context
    return redirect("show_reservations")


from django.contrib.auth.hashers import make_password, check_password
from django.http import JsonResponse


@csrf_exempt
@require_POST
def reserve_court_section(request):
    context = {}
    if request.method == "POST":
        # Parse JSON data from the request body
        data = json.loads(request.body)
        # Access individual fields from the parsed JSON data
        email = data.get("email")
        password = data.get("password")
        courtSectionId = data.get("courtSectionId")
        startTime = data.get("startTime")
        endTime = data.get("endTime")
        date = data.get("date")
        availableSlots=data.get("availableSlots")
  

        try:
            client = Client.objects.get(email=email)

        except Client.DoesNotExist:
            return JsonResponse({"error": "Client not found"}, status=404)
        if password != client.password:
            return JsonResponse({"error": "Incorrect password"}, status=401)

        # courtSectionId = request.POST.get('court_section_id')
        # available_slots = request.POST.get('available_slots')  # This will be a string representation of the list
        courtSection = CourtSection.objects.get(courtSectionId=courtSectionId)
        
        openTime=courtSection.openTime
        closeTime=courtSection.closeTime
        openTime = f"{openTime.hour}:{openTime.minute}"
        closeTime = f"{closeTime.hour}:{closeTime.minute}"

        
        #check if the time fits in available slost
        # Convert startTime, endTime, openTime, and closeTime to total minutes from start of the day
        start_hour, start_minute = map(int, startTime.split(':'))
        end_hour, end_minute = map(int, endTime.split(':'))
        open_hour, open_minute = map(int, openTime.split(':'))
        close_hour, close_minute = map(int, closeTime.split(':'))
        
        start_total_minutes = start_hour * 60 + start_minute
        end_total_minutes = end_hour * 60 + end_minute
        open_total_minutes = open_hour * 60 + open_minute
        close_total_minutes = close_hour * 60 + close_minute
        
        is_within_slot = False

        if start_total_minutes >= open_total_minutes and end_total_minutes <= close_total_minutes and end_total_minutes>open_total_minutes:
            for slot in availableSlots:
                start = slot[0]
                end = slot[1]
                slot_start_hour, slot_start_minute = map(int, start.split(':'))
                slot_end_hour, slot_end_minute = map(int, end.split(':'))
                slot_start_total_minutes = slot_start_hour * 60 + slot_start_minute
                slot_end_total_minutes = slot_end_hour * 60 + slot_end_minute
        
                # Check if the reservation time is within the slot interval
                if start_total_minutes >= slot_start_total_minutes and end_total_minutes <= slot_end_total_minutes:
                    is_within_slot = True
                    break
        
        
        
        if(is_within_slot):
            last_reservation_id = Reservation.objects.latest('reservationID').reservationID
            token = str(hash(email+str(last_reservation_id)))[1:]

            reservation = Reservation.objects.create(
                courtsectionID=courtSection,
                date=date,
                startTime=startTime,
                endTime=endTime,
                token=token,
                clientId=client,
            )
            duration=end_total_minutes-start_total_minutes
            price=duration*courtSection.pricePerHour
            #        {% comment %}  {% endcomment %}

            reservation.save()
            context = {}
            return JsonResponse({"message": "reservation successful","token":token,"price":price}, status=200)
        else:
            return JsonResponse({"error": "Time not available"}, status=400)


        return render(
            request, "home.html", context
        )  # Change 'success_page' to your success page URL name

    # If the request method is GET or if form submission fails, render the same page with the form
    return render(request, "home.html", context)


def show_reservations(request):
    context = request.session.get("reservation_context", {})
    return render(request, "reservations.html", context)


from PIL import Image
from io import BytesIO
import numpy as np
import requests


from django.shortcuts import render, redirect
from django.http import HttpResponse
import json
from django.urls import reverse


@csrf_exempt
@require_POST
def submit_user_creation_form(request):
    if request.method != "POST":
        return HttpResponseBadRequest("Invalid request method")

    if request.method == "POST":
        data = request.POST
        # Extract data from request.POST dictionary (similar to form values)
        first_name = data.get("firstName")
        last_name = data.get("lastName")
        email = data.get("email")
        password = data.get("password")
        phone_number = data.get("number")
        country = data.get("country")
        address = data.get("address")
        date_of_birth = data.get("date_of_birth")
        sex = data.get("sex")

        # Prepare user data dictionary
        user_data = {
            "firstName": first_name,
            "lastName": last_name,
            "email": email,
            "password": password,
            "phoneNumber": phone_number,
            "country": country,
            "address": address,
            "dateOfBirth": date_of_birth,
            "sex": sex,
        }

        # Implement your logic for sending the POST request (using libraries like requests)
        # Replace with your actual backend URL and logic for handling response
        response = requests.post(
            f"http://localhost:8000/backend/create_user/", json=user_data
        )

        if response.ok:  # Assuming successful creation returns 200
            # User created successfully, redirect or display confirmation message
            # try:

            #     user_face = request.FILES["userFace"]
            #     if user_face:
            #         image_data = user_face.read()

            #         img = Image.open(BytesIO(image_data))
            #         img = img.convert("RGB")
            #         img.show()
            #         image_array = np.array(img)
            #         image_list = image_array.tolist()
            #         payload = {"image": image_list, "identity": email}
            #         json_payload = json.dumps(payload)

            #         # Send HTTP POST request
            #         url = "http://127.0.0.1:5000/embeddingCreation"  # Replace with your API endpoint
            #         response = requests.post(url, json=json_payload)
            #         print(response.text)
            # except:
            #     print("no image")

            courtSectionId = data.get("courtSectionId")
            selected_date = data.get("date")
            return redirect(
                reverse("available_times")
                + f"?courtSectionId={courtSectionId}&date={selected_date}"
            )
        else:

            courtSectionId = data.get("courtSectionId")
            selected_date = data.get("date")
            return redirect(
                reverse("available_times")
                + f"?courtSectionId={courtSectionId}&date={selected_date}"
            )
            # Handle creation failure
            return JsonResponse({"message": "Error creating user"}, status=500)


def getReviews(request, court_section_id):
    """
    View to handle displaying a review form for a specific court section.
    """

    # Handle form submission logic here (if applicable)
    if request.method == "GET":

        # Get the CourtSection object with the provided ID
        court_section = get_object_or_404(CourtSection, pk=court_section_id)
        review_dicts = {}
        reviews = []
        reservations = Reservation.objects.filter(courtsectionID=court_section)
        for reservation in reservations:
            tmp = Review.objects.filter(reservationId=reservation)
            if tmp.exists():
                for review in tmp:
                    reviews.append(review)

        review_dicts = [
            {
                "reservationId": review.reservationId,
                "rating": review.rating,
                "comment": review.comment,
                "created_at": review.created_at,
            }
            for review in reviews
        ]

        context = {
            "court_section": court_section,
            "reservations": reservations,
            "reviews": review_dicts,
        }

        return render(
            request, "reviews.html", context
        )  # Redirect after successful submission (adjust as needed)

    context = {"court_section": court_section}
    return render(request, "write_review.html", context)  # Render review form template

import datetime


def rating_form(request):
    if request.method == 'POST':
        # Get data from the form
        comment = request.POST.get('comment')
        rating = request.POST.get('rating')
        token = request.POST.get('token')
        reservation = get_object_or_404(Reservation, token=token)

        # Get current date
        formatted_date = datetime.date.today().strftime('%Y:%m:%d')
        
        # Package data in JSON format
        
        # Create a new Review object
        review = Review.objects.create(
            reservationId=reservation,
            rating=rating,
            comment=comment,
            created_at=formatted_date
        )
    
    # Save the Review object
        review.save()
        
        # Here you can send the data via an API, save it to the database, or perform any other desired actions
        
        # For demonstration purposes, just return the data as JSON
        return JsonResponse({"data": "Review submitted successfully"})
    else:
        return render(request, 'rating_form.html')
