# frontend/views.py
import pretty_errors
from django.shortcuts import render, get_object_or_404
from django.http import HttpResponse, HttpResponseBadRequest
from datetime import timedelta, datetime
from backend.models import CourtSection, Reservation, Court, Admin, Client
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
    for courtSection in courtSections:
        image_path = f"frontend/courtSectionsImages/{courtSection.courtSectionId}.jpeg"
        courtSection.image_path = (
            image_path  # Add image_path as an attribute to each object
        )

    context = {
        "courtSections": courtSections,
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


# @csrf_exempt
# @require_GET
# def available_times(request):
#     logger.info(f"Received {request.method} request from {request.META['REMOTE_ADDR']}")
#     if request.method == "GET":
#         context = {}
#         courtSectionId = request.GET.get("courtSectionId")
#         selected_date = request.GET.get("date")

#         # Check if courtSectionId or selected_date are None
#         if courtSectionId is None or selected_date is None:
#             return False

#         courtSectionId = int(courtSectionId)

#         year, month, day = map(int, selected_date.split("-"))
#         # Construct a date object
#         dateObj = date(year, month, day)
#         # date = datetime.strptime(str(selected_date), '%Y-%m-%d').date()
#         court_section = CourtSection.objects.get(courtSectionId=courtSectionId)

#         # Check if open and close times are set
#         if not court_section.openTime or not court_section.closeTime:
#             return render(request, "home.html", context)

#         # Get all reservations for the court section on the selected date
#         reservations = Reservation.objects.filter(
#             courtsectionID=court_section, date=dateObj
#         )
#         # List to store tuples of variables
#         reservations_data = []
#         openTime = court_section.openTime
#         closeTime = court_section.closeTime
#         # Iterate over reservations and save variables as tuple in the list
#         for reservation in reservations:
#             reservation_tuple = (reservation.startTime, reservation.endTime)
#             reservations_data.append(reservation_tuple)

#         # Initialize list to store available time slots
#         available_slots = []
#         if not reservations_data:
#             context = {
#                 "court_section": {
#                     "courtSectionId": court_section.courtSectionId,
#                     "courtId": court_section.courtId,
#                     "sectionName": court_section.sectionName,
#                     "sectionType": court_section.sectionType,
#                     "fansCapacity": court_section.fansCapacity,
#                     "openTime": court_section.openTime,
#                     "closeTime": court_section.closeTime,
#                 },
#                 "date": dateObj,
#                 "available_slots": [[openTime, closeTime]],
#             }
#             request.session["reservation_context"] = context

#             return redirect("show_reservations")

#         reservations_data.sort(
#             key=lambda x: x[0]
#         )  # Assuming index 0 represents start time

#         # Check if there are reservations for the court
#         if reservations_data:
#             # Calculate available time slots between reservations and opening/closing times
#             if reservations_data[0][0] > openTime:
#                 available_slots.append((openTime, reservations_data[0][0]))

#             available_slots.extend(
#                 (reservations_data[i][1], reservations_data[i + 1][0])
#                 for i in range(len(reservations_data) - 1)
#                 if reservations_data[i][1] < reservations_data[i + 1][0]
#             )
#             if reservations_data[-1][1] < closeTime:
#                 available_slots.append((reservations_data[-1][1], closeTime))
#         else:
#             # If there are no reservations, consider the entire time as available
#             available_slots.append((openTime, closeTime))

#         time_strings = []
#         for time_tuple in available_slots:
#             # for start,end in time_tuple:
#             startStr = f"{time_tuple[0].hour}:{time_tuple[0].minute}"
#             endStr = f"{time_tuple[1].hour}:{time_tuple[1].minute}"

#             time_strings.append((startStr, endStr))
#         available_slots = time_strings
#         context = {
#             "court_section": court_section,
#             "date": dateObj,
#             "available_slots": available_slots,
#         }

#         return render(request, "reservations.html", context)
#     return HttpResponseBadRequest("Invalid request")

from django.contrib.auth.hashers import make_password,check_password
from django.http import JsonResponse

@csrf_exempt
@require_POST
def reserve_court_section(request, courtSectionId):
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


        strr=make_password(password)
        print(str)

        try:
            client = Client.objects.get(email=email)
            
        except Client.DoesNotExist:
            return JsonResponse({'error': 'Client not found'}, status=404)
        if password!=client.password:
            return JsonResponse({'error': 'Incorrect password'}, status=401)



        # courtSectionId = request.POST.get('court_section_id')
        # available_slots = request.POST.get('available_slots')  # This will be a string representation of the list
        courtSection = CourtSection.objects.get(courtSectionId=courtSectionId)
        reservation = Reservation.objects.create(
            courtsectionID=courtSection,
            date=date,
            startTime=startTime,
            endTime=endTime,
        )
        reservation.save()
        context = {}
        return JsonResponse({'message': 'reservation successful'}, status=200)

        return render(
            request, "home.html", context
        )  # Change 'success_page' to your success page URL name

    # If the request method is GET or if form submission fails, render the same page with the form
    return render(request, "home.html", context)


def show_reservations(request):
    context = request.session.get("reservation_context", {})
    return render(request, "reservations.html", context)
