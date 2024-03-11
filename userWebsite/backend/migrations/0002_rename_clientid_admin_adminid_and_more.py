# Generated by Django 5.0.3 on 2024-03-11 10:58

import phonenumber_field.modelfields
from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('backend', '0001_initial'),
    ]

    operations = [
        migrations.RenameField(
            model_name='admin',
            old_name='clientID',
            new_name='adminId',
        ),
        migrations.RenameField(
            model_name='client',
            old_name='clientID',
            new_name='clientId',
        ),
        migrations.RemoveField(
            model_name='admin',
            name='mName',
        ),
        migrations.RemoveField(
            model_name='client',
            name='mName',
        ),
        migrations.RemoveField(
            model_name='client',
            name='username',
        ),
        migrations.AddField(
            model_name='admin',
            name='email',
            field=models.EmailField(max_length=254, null=True, unique=True),
        ),
        migrations.AddField(
            model_name='client',
            name='email',
            field=models.EmailField(max_length=254, null=True, unique=True),
        ),
        migrations.AddField(
            model_name='client',
            name='firstName',
            field=models.CharField(max_length=20, null=True),
        ),
        migrations.AddField(
            model_name='client',
            name='lastName',
            field=models.CharField(max_length=20, null=True),
        ),
        migrations.AddField(
            model_name='client',
            name='number',
            field=phonenumber_field.modelfields.PhoneNumberField(max_length=128, null=True, region=None),
        ),
        migrations.AddField(
            model_name='reservation',
            name='token',
            field=models.CharField(max_length=100, null=True),
        ),
    ]
