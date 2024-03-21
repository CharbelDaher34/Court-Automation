from django.shortcuts import render

# Create your views here.
from .seeder import MySeeder

def seeder(request):
    # Instantiate MySeeder class
    seeder = MySeeder()
    seeder.run()
    
    # Your view logic here
    return "SEeded"