from django.urls import path
from . import views

urlpatterns = [
    path('seed/', view=views.seeder, name='seeder'),
    # other URL patterns...
]
