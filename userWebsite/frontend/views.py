# frontend/views.py

from django.shortcuts import render
from django.http import HttpResponseRedirect, HttpResponse

def home_view(request):
    context={}
    return render(request, 'home.html',context)
