from django.db import models

# Create your models here.
from django.db import models


class admin(models.Model):
    clientID = models.IntegerField(primary_key=True)
    username = models.CharField(max_length=100)
    password = models.CharField(max_length=100)
    mName = models.CharField(max_length=100)


class Court(models.Model):
    courtId = models.IntegerField(primary_key=True)
    name = models.CharField(max_length=100)
    location = models.CharField(max_length=100)
    adminId = models.ForeignKey(admin, on_delete=models.CASCADE)

class CourtSection(models.Model):
    CourtSectionID = models.IntegerField(primary_key=True)
    courtsectionID = models.ForeignKey(Court, on_delete=models.CASCADE)
    locatedin = models.CharField(max_length=100)  # Might be a foreign key to another table

class Food(models.Model):
    foodID = models.IntegerField(primary_key=True)
    IName = models.CharField(max_length=100)
    description = models.TextField()
    unitPrice = models.DecimalField(max_digits=10, decimal_places=2)

class Inventory(models.Model):
    InventoryID = models.IntegerField(primary_key=True)
    itemName = models.CharField(max_length=100)
    unitPrice_hour = models.DecimalField(max_digits=10, decimal_places=2)
    quantity = models.IntegerField()


class Cilent(models.Model):
    clientID = models.IntegerField(primary_key=True)
    username = models.CharField(max_length=100)
    password = models.CharField(max_length=100)
    mName = models.CharField(max_length=100)


class Reservation(models.Model):
    reservationID = models.IntegerField(primary_key=True)
    clientID = models.ForeignKey(Cilent, on_delete=models.CASCADE)
    courtsectionID = models.ForeignKey(CourtSection, on_delete=models.CASCADE)
    startTime = models.DateTimeField()
    endTime = models.DateTimeField()

class FoodPurchase(models.Model):
    purchaseID = models.IntegerField(primary_key=True)
    reservationID = models.ForeignKey(Reservation, on_delete=models.CASCADE)
    foodID = models.ForeignKey(Food, on_delete=models.CASCADE)
    quantity = models.IntegerField()
    purchaseDate = models.DateField()

class VendingMachine(models.Model):
    vendingMachineID = models.IntegerField(primary_key=True)
    courtSectionID = models.ForeignKey(CourtSection, on_delete=models.CASCADE)  # Might be many-to-many relationship
    contains = models.ManyToManyField(Inventory, through='InventoryRent')  # ManyToMany relationship

class InventoryRent(models.Model):
    InventoryID = models.ForeignKey(Inventory, on_delete=models.CASCADE)
    vendingMachineID = models.ForeignKey(VendingMachine, on_delete=models.CASCADE)
