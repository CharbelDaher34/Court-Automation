# frontend/views.py

from django.shortcuts import render,get_object_or_404
from django.http import HttpResponseRedirect, HttpResponse
from datetime import timedelta
from .models import CourtSection, Reservation



def home_view(request):
    context={}
    return render(request, 'home.html',context)



def available_times(request, court_section_id, date):
  """
  This view retrieves available times for a court section on a chosen date.
  """
  court_section = get_object_or_404(CourtSection, pk=court_section_id)

  # Check if open and close times are set
  if not court_section.openTime or not court_section.closeTime:
    return render(request, 'reservations/available_times.html', {
      'court_section': court_section,
      'date': date,
      'available_times': [],
      'error_message': "Court section does not have open or close times defined."
    })

  # Convert date and times to datetime objects for easier manipulation
  selected_date = datetime.datetime.strptime(date, '%Y-%m-%d').date()
  open_time = court_section.openTime
  close_time = court_section.closeTime

  # Get all reservations for the court section on the selected date
  reservations = Reservation.objects.filter(
      court_section=court_section,
      date=selected_date
  )

  # Initialize list to store available time slots
  available_times = []

  # Loop through each hour between open and close time
  current_time = open_time
  while current_time < close_time:
    # Check for overlapping reservations
    overlapping_reservation = reservations.filter(
      startTime__lt=current_time + timedelta(hours=1),
      endTime__gt=current_time
    ).first()

    if not overlapping_reservation:
      # No overlapping reservation, add time slot to available
      available_times.append({
        'start_time': current_time.strftime('%H:%M:%S'),
        'end_time': (current_time + timedelta(hours=1)).strftime('%H:%M:%S')
      })
    
    # Move to the next hour
    current_time += timedelta(hours=1)

  context = {
    'court_section': court_section,
    'date': date,
    'available_times': available_times,
  }
  return render(request, 'reservations/available_times.html', context)

