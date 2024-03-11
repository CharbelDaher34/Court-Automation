from django.db import models

# Create your models here.
from phonenumber_field.modelfields import PhoneNumberField


class admin(models.Model):
    adminId = models.IntegerField(primary_key=True)
    username = models.CharField(max_length=100)
    password = models.CharField(max_length=100)
    email = models.EmailField(max_length=254, unique=True, null=True)


class Court(models.Model):
    courtId = models.IntegerField(primary_key=True)
    name = models.CharField(max_length=100)
    location = models.CharField(max_length=100)
    adminId = models.ForeignKey(admin, on_delete=models.CASCADE)

class CourtSection(models.Model):
    courtSectionId = models.IntegerField(primary_key=True)
    courtId = models.ForeignKey(Court, on_delete=models.CASCADE)
    sectionName = models.CharField(max_length=100)
    TYPE_CHOICES = [
        ('basketball', 'basketball 1'),
        ('football', 'footvall'),
        ('tennis', 'tennis'),
    ]
    sectionType = models.CharField(max_length=20, choices=TYPE_CHOICES)
    fansCapacity = models.IntegerField()
    

class VendingMachine(models.Model):
    vendingMachineId = models.IntegerField(primary_key=True)
    courtSectionId = models.ForeignKey(CourtSection, on_delete=models.CASCADE)  # Might be many-to-many relationship


class Food(models.Model):
    foodId = models.IntegerField(primary_key=True)
    name = models.CharField(max_length=100)
    description = models.TextField()
    unitPrice = models.DecimalField(max_digits=10, decimal_places=2)
    quantity = models.IntegerField()
    Maxquantity = models.IntegerField()
    vendingMachineId = models.ForeignKey(VendingMachine, on_delete=models.CASCADE)  # ManyToMany relationship


class Client(models.Model):
    clientId = models.IntegerField(primary_key=True)
    password = models.CharField(max_length=100)
    firstName = models.CharField(max_length=20,null=True)
    lastName = models.CharField(max_length=20,null=True)

    email = models.EmailField(max_length=254, unique=True, null=True)
    number = PhoneNumberField(null=True)


class Reservation(models.Model):
    reservationID = models.IntegerField(primary_key=True)
    clientId = models.ForeignKey(Client, on_delete=models.CASCADE)
    courtsectionID = models.ForeignKey(CourtSection, on_delete=models.CASCADE)
    date = models.DateField()
    startTime = models.TimeField()
    endTime = models.TimeField()
    token = models.CharField(max_length=100,null=True)




class FoodPurchase(models.Model):
    purchaseId = models.IntegerField(primary_key=True)
    reservationId = models.ForeignKey(Reservation, on_delete=models.CASCADE)
    foodId = models.ForeignKey(Food, on_delete=models.CASCADE)
    quantity = models.IntegerField()


class InventorySports(models.Model):
    inventoryId = models.IntegerField(primary_key=True)
    itemName = models.CharField(max_length=100)
    unitPrice_hour = models.DecimalField(max_digits=10, decimal_places=2)
    quantity = models.IntegerField()


class InventoryRent(models.Model):
    inventoryRentId =  models.IntegerField(primary_key=True)
    inventoryId = models.ForeignKey(InventorySports, on_delete=models.CASCADE)
    reservationId = models.ForeignKey(Reservation, on_delete=models.CASCADE)
    