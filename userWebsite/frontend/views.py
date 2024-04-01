# frontend/views.py
import pretty_errors
from django.shortcuts import render,get_object_or_404,redirect
from django.http import HttpResponseRedirect, HttpResponse
from datetime import timedelta,datetime
from backend.models import CourtSection, Reservation, Court,Admin
import json

def home_view(request):
    courtDetails=[]
    courts=Court.objects.all()
    for court in courts:
        admin=Admin.objects.get(adminId=court.adminId.adminId)
        courtDetails.append((court.courtId,court.name,court.location,admin.username,admin.number))
    context={
        "courtDetails":courtDetails
    }
    return render(request, 'home.html',context)


def courtSectionView(request,courtId):
    courtSections=CourtSection.objects.filter(courtId=courtId)
    
    context = {
      'courtSections': courtSections,
    }
    return render(request,'court_section.html',context)

def available_times(request, courtSectionId):
  """
  This view retrieves available times for a court section on a chosen date.
  """
  context={}
  selected_date = request.POST.get('date')
  court_section=CourtSection.objects.get(courtSectionId=courtSectionId)
        
  date = datetime.strptime(str(selected_date), '%Y-%m-%d').date()

  # Check if open and close times are set
  if not court_section.openTime or not court_section.closeTime:
      return render(request, 'home.html',context)

 

  # Get all reservations for the court section on the selected date
  reservations = Reservation.objects.filter(
      courtsectionID=court_section,
      date=date
  )
  a=len(reservations)
  # List to store tuples of variables
  reservations_data = []
  openTime = court_section.openTime
  closeTime = court_section.closeTime
  # Iterate over reservations and save variables as tuple in the list
  for reservation in reservations:
      reservation_tuple = (reservation.startTime, reservation.endTime)
      reservations_data.append(reservation_tuple)
  
  
  # Initialize list to store available time slots
  available_slots = []
  if len(reservations_data)==0:
    context = {
      'court_section': court_section,
      'date': date,
      'available_slots': [(openTime, closeTime)]
     }
    
    return render(request, 'reservations.html', context)
      
      
      
  reservations_data.sort(key=lambda x: x[0])  # Assuming index 0 represents start time
  
  # Check if there are reservations for the court
  if reservations_data:
      # Calculate available time slots between reservations and opening/closing times
      if reservations_data[0][0] > openTime:
          available_slots.append((openTime, reservations_data[0][0]))
      
      for i in range(len(reservations_data) - 1):
          if reservations_data[i][1] < reservations_data[i + 1][0]:
              available_slots.append((reservations_data[i][1], reservations_data[i + 1][0]))
      
      if reservations_data[-1][1] < closeTime:
          available_slots.append((reservations_data[-1][1], closeTime))
  else:
      # If there are no reservations, consider the entire time as available
      available_slots.append((openTime, closeTime))




  context = {
    'court_section': court_section,
    'date': date,
    'available_slots': available_slots,
  }
  return render(request, 'reservations.html', context)





def reserve_court_section(request,courtSectionId,date):
    context={}
    if request.method == 'POST':
        
        # courtSectionId = request.POST.get('court_section_id')
        # available_slots = request.POST.get('available_slots')  # This will be a string representation of the list
        courtSection=CourtSection.objects.get(courtSectionId=courtSectionId)
        start_time = request.POST.get('start_time')
        end_time = request.POST.get('end_time')
        
        valid_time = False
        for slot in available_slots:
          if start_time >= slot[0].strftime('%H:%M:%S') and end_time <= slot[1].strftime('%H:%M:%S'):
            valid_time = True
            break
    
        if not valid_time:
          context['error_message'] = 'Selected time slot is not available.'
          context = {
             'court_section': courtSection,
             'date': date,
             'available_slots': available_times,
           }
          return render(request, 'reservations.html', context)


        # Perform validation of start_time and end_time if necessary

        # Assuming court_section and date are available in the context
        # Create a new Reservation object and save it
        courtSection=CourtSection.objects.get(courtSectionId=courtSectionId)
        reservation = Reservation.objects.create(
            court_section=courtSection,
            date=date,
            startTime=start_time,
            endTime=end_time
        )

        # Redirect to a success page or the same page with a success message
        return redirect('success_page')  # Change 'success_page' to your success page URL name

    # If the request method is GET or if form submission fails, render the same page with the form
    return render(request, 'your_template.html', context)

