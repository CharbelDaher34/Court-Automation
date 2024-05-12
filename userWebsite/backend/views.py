from django.shortcuts import render
import json
# Create your views here.
from .seeder import MySeeder
from django.shortcuts import render, redirect
from django.contrib.auth.models import User
from .models import Client  # Import your Client model
from django.contrib import messages
from django.views.decorators.csrf import csrf_exempt

from django.http import HttpResponse
from django.views.decorators.http import  require_POST
from django.http import JsonResponse


def seeder(request):
    # Instantiate MySeeder class
    seeder = MySeeder()
    seeder.run()

    # Your view logic here
    return "SEeded"

@csrf_exempt
@require_POST
def create_user(request):
    if request.method == "POST":
        data = json.loads(request.body)

        first_name = data.get("firstName")
        last_name = data.get("lastName")
        email = data.get("email")
        password = data.get("password")
        phone_number = data.get("number")
        country = data.get("country")
        address = data.get("address")
        date_of_birth = data.get("date_of_birth")
        sex = data.get("sex")

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
            client.save();
            return JsonResponse({"message": "User created successfully"}, status=201)

        except Exception as e:
            return JsonResponse({"message": f"Error creating user: {e}"}, status=400)

    else:
        return JsonResponse({"message": f"Method not allowed"}, status=405)
