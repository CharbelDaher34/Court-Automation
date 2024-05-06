from django.shortcuts import render

# Create your views here.
from .seeder import MySeeder
from django.shortcuts import render, redirect
from django.contrib.auth.models import User
from .models import Client  # Import your Client model
from django.contrib import messages
from django.views.decorators.csrf import csrf_exempt

from django.http import HttpResponse


def seeder(request):
    # Instantiate MySeeder class
    seeder = MySeeder()
    seeder.run()

    # Your view logic here
    return "SEeded"

@csrf_exempt
def create_user(request):
    if request.method == "POST":
        first_name = request.POST.get("firstName")
        last_name = request.POST.get("lastName")
        email = request.POST.get("email")
        password = request.POST.get("password")
        phone_number = request.POST.get("number")
        country = request.POST.get("country")
        address = request.POST.get("address")
        date_of_birth = request.POST.get("date_of_birth")
        sex = request.POST.get("sex")

        try:
            client = Client.objects.create(
                password=password,
                firstName=first_name,
                lastName=last_name,
                email=email,
                number=phone_number,
                country=country,
                address=address,
                date_of_birth=date_of_birth,
                sex=sex,
            )
          
            messages.success(request, "User created successfully!")
            return HttpResponse("User created successfully", status=201)  # 201 Created status

        except Exception as e:
            messages.error(request, f"Error creating user: {e}")
            return HttpResponse(f"Error creating user: {e}", status=400)  # 400 Bad Request status

    else:
        return HttpResponse("Method not allowed", status=405)
