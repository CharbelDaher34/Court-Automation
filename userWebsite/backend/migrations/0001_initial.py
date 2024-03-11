# Generated by Django 5.0.3 on 2024-03-11 08:28

import django.db.models.deletion
from django.db import migrations, models


class Migration(migrations.Migration):

    initial = True

    dependencies = [
    ]

    operations = [
        migrations.CreateModel(
            name='admin',
            fields=[
                ('clientID', models.IntegerField(primary_key=True, serialize=False)),
                ('username', models.CharField(max_length=100)),
                ('password', models.CharField(max_length=100)),
                ('mName', models.CharField(max_length=100)),
            ],
        ),
        migrations.CreateModel(
            name='Client',
            fields=[
                ('clientID', models.IntegerField(primary_key=True, serialize=False)),
                ('username', models.CharField(max_length=100)),
                ('password', models.CharField(max_length=100)),
                ('mName', models.CharField(max_length=100)),
            ],
        ),
        migrations.CreateModel(
            name='Food',
            fields=[
                ('foodId', models.IntegerField(primary_key=True, serialize=False)),
                ('name', models.CharField(max_length=100)),
                ('description', models.TextField()),
                ('unitPrice', models.DecimalField(decimal_places=2, max_digits=10)),
                ('quantity', models.IntegerField()),
                ('Maxquantity', models.IntegerField()),
            ],
        ),
        migrations.CreateModel(
            name='InventorySports',
            fields=[
                ('inventoryId', models.IntegerField(primary_key=True, serialize=False)),
                ('itemName', models.CharField(max_length=100)),
                ('unitPrice_hour', models.DecimalField(decimal_places=2, max_digits=10)),
                ('quantity', models.IntegerField()),
            ],
        ),
        migrations.CreateModel(
            name='Court',
            fields=[
                ('courtId', models.IntegerField(primary_key=True, serialize=False)),
                ('name', models.CharField(max_length=100)),
                ('location', models.CharField(max_length=100)),
                ('adminId', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to='backend.admin')),
            ],
        ),
        migrations.CreateModel(
            name='CourtSection',
            fields=[
                ('courtSectionId', models.IntegerField(primary_key=True, serialize=False)),
                ('sectionName', models.CharField(max_length=100)),
                ('sectionType', models.CharField(choices=[('basketball', 'basketball 1'), ('football', 'footvall'), ('tennis', 'tennis')], max_length=20)),
                ('fansCapacity', models.IntegerField()),
                ('courtId', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to='backend.court')),
            ],
        ),
        migrations.CreateModel(
            name='Reservation',
            fields=[
                ('reservationID', models.IntegerField(primary_key=True, serialize=False)),
                ('date', models.DateField()),
                ('startTime', models.TimeField()),
                ('endTime', models.TimeField()),
                ('clientId', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to='backend.client')),
                ('courtsectionID', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to='backend.courtsection')),
            ],
        ),
        migrations.CreateModel(
            name='InventoryRent',
            fields=[
                ('inventoryRentId', models.IntegerField(primary_key=True, serialize=False)),
                ('inventoryId', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to='backend.inventorysports')),
                ('reservationId', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to='backend.reservation')),
            ],
        ),
        migrations.CreateModel(
            name='FoodPurchase',
            fields=[
                ('purchaseId', models.IntegerField(primary_key=True, serialize=False)),
                ('quantity', models.IntegerField()),
                ('foodId', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to='backend.food')),
                ('reservationId', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to='backend.reservation')),
            ],
        ),
        migrations.CreateModel(
            name='VendingMachine',
            fields=[
                ('vendingMachineId', models.IntegerField(primary_key=True, serialize=False)),
                ('courtSectionId', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to='backend.courtsection')),
            ],
        ),
        migrations.AddField(
            model_name='food',
            name='vendingMachineId',
            field=models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to='backend.vendingmachine'),
        ),
    ]
