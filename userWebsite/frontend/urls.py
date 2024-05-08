# frontend/urls.py

from django.urls import path
from . import views

urlpatterns = [
    path('home/', view=views.home_view, name='home'),
    # other URL patterns...
    path('available_times/', views.available_times, name='available_times'),
    path('court_sections/<courtId>/',views.courtSectionView, name='courtSectionView'),
    path('reserve_court_section/<int:courtSectionId>/', views.reserve_court_section, name='reserve_court_section'),
    path('show_reservations/', views.show_reservations, name='show_reservations'),

]

