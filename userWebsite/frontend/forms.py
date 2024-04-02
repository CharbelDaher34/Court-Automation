from django import forms

class ReserveCourtSectionForm(forms.Form):
    start_time = forms.TimeField(label='Start Time', widget=forms.TimeInput(attrs={'type': 'time'}))
    end_time = forms.TimeField(label='End Time', widget=forms.TimeInput(attrs={'type': 'time'}))
    court_section_id = forms.CharField(widget=forms.HiddenInput)
    available_slots = forms.CharField(widget=forms.HiddenInput)
    

