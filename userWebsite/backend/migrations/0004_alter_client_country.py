# Generated by Django 5.0.3 on 2024-04-01 14:13

import django_countries.fields
from django.db import migrations


class Migration(migrations.Migration):

    dependencies = [
        ('backend', '0003_admin_number'),
    ]

    operations = [
        migrations.AlterField(
            model_name='client',
            name='country',
            field=django_countries.fields.CountryField(max_length=2, null=True),
        ),
    ]