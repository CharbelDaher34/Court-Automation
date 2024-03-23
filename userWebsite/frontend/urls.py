# frontend/urls.py

from django.urls import path
from . import views

urlpatterns = [
    path('home/', view=views.home_view, name='home'),
    # other URL patterns...
    path('available_times/<courtSectionId>/', views.available_times, name='available_times'),
    path('court_sections/<courtId>/',views.courtSectionView, name='courtSectionView'),
]

