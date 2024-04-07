from django import forms

class ReserveCourtSectionForm(forms.Form):
    def __init__(self, available_slots, *args, **kwargs):
        self.available_slots = available_slots
        super().__init__(*args, **kwargs)

        s = "".join(
            f"{x[0].strftime('%H:%M')}--->{x[1].strftime('%H:%M')}\n"
            for x in available_slots
        )
        if self.available_slots is not None:
            self.fields['available_slots_label'].initial = s

        start_time_choices = [(start.strftime('%H:%M'), start.strftime('%H:%M')) for start, end in available_slots]
        self.fields['start_time'].choices = start_time_choices
        
    def get_available_slots(self):
        return self.available_slots   
    start_time = forms.TimeField(label='Start Time', widget=forms.TimeInput(attrs={'type': 'time'}))
    end_time = forms.TimeField(label='End Time', widget=forms.TimeInput(attrs={'type': 'time'}))
    available_slots_label = forms.CharField(widget=forms.widgets.Textarea(attrs={'rows': '4', 'cols': '50', 'readonly': True}), initial="" ) # Create a readonly textarea

    
