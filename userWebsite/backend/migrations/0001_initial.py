# Generated by Django 5.0.3 on 2024-03-21 15:18

import django.db.models.deletion
import phonenumber_field.modelfields
from django.db import migrations, models


class Migration(migrations.Migration):

    initial = True

    dependencies = [
    ]

    operations = [
        migrations.CreateModel(
            name='Admin',
            fields=[
                ('adminId', models.AutoField(primary_key=True, serialize=False)),
                ('username', models.CharField(max_length=100)),
                ('password', models.CharField(max_length=100)),
                ('email', models.EmailField(max_length=254, null=True, unique=True)),
            ],
        ),
        migrations.CreateModel(
            name='Client',
            fields=[
                ('clientId', models.AutoField(primary_key=True, serialize=False)),
                ('password', models.CharField(max_length=100)),
                ('firstName', models.CharField(max_length=20, null=True)),
                ('lastName', models.CharField(max_length=20, null=True)),
                ('email', models.EmailField(max_length=254, null=True, unique=True)),
                ('number', phonenumber_field.modelfields.PhoneNumberField(max_length=128, null=True, region=None, unique=True)),
                ('address', models.CharField(max_length=200, null=True)),
                ('country', models.CharField(max_length=100, null=True)),
                ('date_of_birth', models.DateField(null=True)),
                ('sex', models.CharField(choices=[('M', 'Male'), ('F', 'Female')], max_length=1, null=True)),
            ],
        ),
        migrations.CreateModel(
            name='Dealer',
            fields=[
                ('dealer_id', models.AutoField(primary_key=True, serialize=False)),
                ('name', models.CharField(max_length=100)),
                ('address', models.CharField(max_length=200)),
                ('contact_info', models.CharField(max_length=100)),
                ('marginOfProfit', models.FloatField()),
            ],
        ),
        migrations.CreateModel(
            name='InventorySports',
            fields=[
                ('inventoryId', models.AutoField(primary_key=True, serialize=False)),
                ('itemName', models.CharField(max_length=100)),
                ('unitPrice_hour', models.DecimalField(decimal_places=2, max_digits=10)),
                ('quantity', models.IntegerField()),
                ('typeChoices', models.CharField(choices=[('basketball', 'basketball'), ('football', 'footvall'), ('tennis', 'tennis')], max_length=20, null=True)),
            ],
        ),
        migrations.CreateModel(
            name='Court',
            fields=[
                ('courtId', models.AutoField(primary_key=True, serialize=False)),
                ('name', models.CharField(max_length=100)),
                ('location', models.CharField(max_length=100)),
                ('adminId', models.ForeignKey(null=True, on_delete=django.db.models.deletion.SET_NULL, to='backend.admin')),
            ],
        ),
        migrations.CreateModel(
            name='CourtSection',
            fields=[
                ('courtSectionId', models.AutoField(primary_key=True, serialize=False)),
                ('sectionName', models.CharField(max_length=100)),
                ('sectionType', models.CharField(choices=[('basketball', 'basketball'), ('football', 'football'), ('tennis', 'tennis')], max_length=20)),
                ('fansCapacity', models.IntegerField()),
                ('courtId', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to='backend.court')),
            ],
        ),
        migrations.CreateModel(
            name='Food',
            fields=[
                ('foodId', models.AutoField(primary_key=True, serialize=False)),
                ('name', models.CharField(max_length=100)),
                ('description', models.TextField()),
                ('unitPrice', models.DecimalField(decimal_places=2, max_digits=10)),
                ('quantity', models.IntegerField()),
                ('Maxquantity', models.IntegerField()),
                ('dealer_id', models.ForeignKey(null=True, on_delete=django.db.models.deletion.SET_NULL, to='backend.dealer')),
            ],
        ),
        migrations.CreateModel(
            name='Reservation',
            fields=[
                ('reservationID', models.AutoField(primary_key=True, serialize=False)),
                ('date', models.DateField()),
                ('startTime', models.TimeField()),
                ('endTime', models.TimeField()),
                ('token', models.CharField(max_length=100, null=True)),
                ('clientId', models.ForeignKey(null=True, on_delete=django.db.models.deletion.SET_NULL, to='backend.client')),
                ('courtsectionID', models.ForeignKey(null=True, on_delete=django.db.models.deletion.SET_NULL, to='backend.courtsection')),
            ],
        ),
        migrations.CreateModel(
            name='InventoryRent',
            fields=[
                ('inventoryRentId', models.AutoField(primary_key=True, serialize=False)),
                ('inventoryId', models.ForeignKey(null=True, on_delete=django.db.models.deletion.SET_NULL, to='backend.inventorysports')),
                ('reservationId', models.ForeignKey(null=True, on_delete=django.db.models.deletion.SET_NULL, to='backend.reservation')),
            ],
        ),
        migrations.CreateModel(
            name='FoodPurchase',
            fields=[
                ('purchaseId', models.AutoField(primary_key=True, serialize=False)),
                ('quantity', models.IntegerField()),
                ('foodId', models.ForeignKey(null=True, on_delete=django.db.models.deletion.SET_NULL, to='backend.food')),
                ('reservationId', models.ForeignKey(null=True, on_delete=django.db.models.deletion.SET_NULL, to='backend.reservation')),
            ],
        ),
        migrations.CreateModel(
            name='VendingMachine',
            fields=[
                ('vendingMachineId', models.AutoField(primary_key=True, serialize=False)),
                ('courtSectionId', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to='backend.courtsection')),
            ],
        ),
        migrations.AddField(
            model_name='food',
            name='vendingMachineId',
            field=models.ForeignKey(null=True, on_delete=django.db.models.deletion.SET_NULL, to='backend.vendingmachine'),
        ),
    ]
