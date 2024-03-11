# frontend/urls.py

from django.urls import path
from . import views

urlpatterns = [
    path('home/', view=views.home_view, name='home'),
    # other URL patterns...
]

