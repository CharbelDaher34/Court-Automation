# frontend/urls.py

from django.urls import path
from . import views

urlpatterns = [
    path('home/', view=views.home_view, name='home'),
    # other URL patterns...
    path('available_times/', views.available_times, name='available_times'),
    path('court_sections/<courtId>/',views.courtSectionView, name='courtSectionView'),
    path('reserve_court_section/', views.reserve_court_section, name='reserve_court_section'),
    path('show_reservations/', views.show_reservations, name='show_reservations'),
    path('submit_user_creation_form/', views.submit_user_creation_form, name='submit_user_creation_form'),
    # path('uploadImage/', views.uploadImage, name='uploadImage'),
    path('getReviews/<int:court_section_id>/', views.getReviews, name='getReviews'),
    path('writeReview/', views.rating_form, name='writeReview'),


]

