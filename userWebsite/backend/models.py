from django.db import models

# Create your models here.
from phonenumber_field.modelfields import PhoneNumberField


class Admin(models.Model):
    adminId = models.AutoField(primary_key=True)
    username = models.CharField(max_length=100)
    password = models.CharField(max_length=100)
    email = models.EmailField(max_length=254, unique=True, null=True)
    number = PhoneNumberField(null=True,unique=True)


class Court(models.Model):
    courtId = models.AutoField(primary_key=True)
    name = models.CharField(max_length=100)
    location = models.CharField(max_length=100)
    adminId = models.ForeignKey(Admin, on_delete=models.SET_NULL,null=True)

class CourtSection(models.Model):
    courtSectionId = models.AutoField(primary_key=True)
    courtId = models.ForeignKey(Court, on_delete=models.CASCADE)
    sectionName = models.CharField(max_length=100)
    TYPE_CHOICES = [
        ('basketball', 'basketball'),
        ('football', 'football'),
        ('tennis', 'tennis'),
    ]
    sectionType = models.CharField(max_length=20, choices=TYPE_CHOICES)
    fansCapacity = models.IntegerField()
    openTime = models.TimeField(null=True)
    closeTime = models.TimeField(null=True)    

class VendingMachine(models.Model):
    vendingMachineId = models.AutoField(primary_key=True)
    courtSectionId = models.ForeignKey(CourtSection, on_delete=models.CASCADE) 



class Dealer(models.Model):
    dealer_id = models.AutoField(primary_key=True)
    name = models.CharField(max_length=100)
    address = models.CharField(max_length=200)
    contact_info = models.CharField(max_length=100)
    marginOfProfit= models.FloatField()


class Food(models.Model):
    foodId = models.AutoField(primary_key=True)
    name = models.CharField(max_length=100)
    description = models.TextField()
    unitPrice = models.DecimalField(max_digits=10, decimal_places=2)
    quantity = models.IntegerField()
    Maxquantity = models.IntegerField()
    vendingMachineId = models.ForeignKey(VendingMachine, on_delete=models.SET_NULL,null=True) 
    dealer_id = models.ForeignKey(Dealer, on_delete=models.SET_NULL,null=True)


class Client(models.Model):
    clientId = models.AutoField(primary_key=True)
    password = models.CharField(max_length=100)
    firstName = models.CharField(max_length=20,null=True)
    lastName = models.CharField(max_length=20,null=True)
    email = models.EmailField(max_length=254, unique=True, null=True)
    number = PhoneNumberField(null=True,unique=True)
    address = models.CharField(max_length=200, null=True)
    country = models.CharField(max_length=100, null=True)
    date_of_birth = models.DateField( null=True)
    sex = models.CharField(max_length=1, choices=[('M', 'Male'), ('F', 'Female')], null=True)
    def identity(self):
        return f"{self.firstName}{self.lastName}({self.email})"

    def __str__(self):
        return self.identity()
    
    

class Reservation(models.Model):
    reservationID = models.AutoField(primary_key=True)
    clientId = models.ForeignKey(Client, on_delete=models.SET_NULL,null=True)

    # clientId = models.ForeignKey(Client, on_delete=models.CASCADE)
    courtsectionID = models.ForeignKey(CourtSection, on_delete=models.SET_NULL,null=True)
    date = models.DateField()
    startTime = models.TimeField()
    endTime = models.TimeField()
    token = models.CharField(max_length=100,null=True)




class FoodPurchase(models.Model):
    purchaseId = models.AutoField(primary_key=True)
    reservationId = models.ForeignKey(Reservation, on_delete=models.SET_NULL,null=True)
    foodId = models.ForeignKey(Food, on_delete=models.SET_NULL,null=True)
    quantity = models.IntegerField()


class InventorySports(models.Model):
    inventoryId = models.AutoField(primary_key=True)
    itemName = models.CharField(max_length=100)
    unitPrice_hour = models.DecimalField(max_digits=10, decimal_places=2)
    quantity = models.IntegerField()
    typeChoices = [
        ('basketball', 'basketball'),
        ('football', 'footvall'),
        ('tennis', 'tennis'),
    ]
    typeChoices = models.CharField(max_length=20, choices=typeChoices, null=True)
class InventoryRent(models.Model):
    inventoryRentId =  models.AutoField(primary_key=True)
    inventoryId = models.ForeignKey(InventorySports, on_delete=models.SET_NULL,null=True)
    reservationId = models.ForeignKey(Reservation, on_delete=models.SET_NULL,null=True)
    
    

