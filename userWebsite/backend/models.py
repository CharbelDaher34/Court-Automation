from django.db import models

# Create your models here.
from phonenumber_field.modelfields import PhoneNumberField


class Admin(models.Model):
    adminId = models.AutoField(primary_key=True)
    username = models.CharField(max_length=100)
    password = models.CharField(max_length=100)
    email = models.EmailField(max_length=254, unique=True, null=True)


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
    
    
    
#     -- MySQL Workbench Forward Engineering

# SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
# SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
# SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

# -- -----------------------------------------------------
# -- Schema mydb
# -- -----------------------------------------------------
# -- -----------------------------------------------------
# -- Schema courtautomation
# -- -----------------------------------------------------

# -- -----------------------------------------------------
# -- Schema courtautomation
# -- -----------------------------------------------------
# CREATE SCHEMA IF NOT EXISTS `courtautomation` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
# USE `courtautomation` ;

# -- -----------------------------------------------------
# -- Table `courtautomation`.`backend_admin`
# -- -----------------------------------------------------
# CREATE TABLE IF NOT EXISTS `courtautomation`.`backend_admin` (
#   `adminId` INT NOT NULL AUTO_INCREMENT,
#   `username` VARCHAR(100) NOT NULL,
#   `password` VARCHAR(100) NOT NULL,
#   `email` VARCHAR(254) NULL DEFAULT NULL,
#   PRIMARY KEY (`adminId`),
#   UNIQUE INDEX `email` (`email` ASC) VISIBLE)
# ENGINE = InnoDB
# DEFAULT CHARACTER SET = utf8mb4
# COLLATE = utf8mb4_0900_ai_ci;


# -- -----------------------------------------------------
# -- Table `courtautomation`.`backend_client`
# -- -----------------------------------------------------
# CREATE TABLE IF NOT EXISTS `courtautomation`.`backend_client` (
#   `clientId` INT NOT NULL AUTO_INCREMENT,
#   `password` VARCHAR(100) NOT NULL,
#   `email` VARCHAR(254) NULL DEFAULT NULL,
#   `firstName` VARCHAR(20) NULL DEFAULT NULL,
#   `lastName` VARCHAR(20) NULL DEFAULT NULL,
#   `number` VARCHAR(128) NULL DEFAULT NULL,
#   `address` VARCHAR(200) NULL DEFAULT NULL,
#   `country` VARCHAR(100) NULL DEFAULT NULL,
#   `date_of_birth` DATE NULL DEFAULT NULL,
#   `sex` VARCHAR(1) NULL DEFAULT NULL,
#   PRIMARY KEY (`clientId`),
#   UNIQUE INDEX `email` (`email` ASC) VISIBLE,
#   UNIQUE INDEX `backend_client_number_7b7bcccd_uniq` (`number` ASC) VISIBLE)
# ENGINE = InnoDB
# DEFAULT CHARACTER SET = utf8mb4
# COLLATE = utf8mb4_0900_ai_ci;


# -- -----------------------------------------------------
# -- Table `courtautomation`.`backend_court`
# -- -----------------------------------------------------
# CREATE TABLE IF NOT EXISTS `courtautomation`.`backend_court` (
#   `courtId` INT NOT NULL AUTO_INCREMENT,
#   `name` VARCHAR(100) NOT NULL,
#   `location` VARCHAR(100) NOT NULL,
#   `adminId_id` INT NULL DEFAULT NULL,
#   PRIMARY KEY (`courtId`),
#   INDEX `backend_court_adminId_id_3ef767d4_fk_backend_admin_adminId` (`adminId_id` ASC) VISIBLE,
#   CONSTRAINT `backend_court_adminId_id_3ef767d4_fk_backend_admin_adminId`
#     FOREIGN KEY (`adminId_id`)
#     REFERENCES `courtautomation`.`backend_admin` (`adminId`))
# ENGINE = InnoDB
# DEFAULT CHARACTER SET = utf8mb4
# COLLATE = utf8mb4_0900_ai_ci;


# -- -----------------------------------------------------
# -- Table `courtautomation`.`backend_courtsection`
# -- -----------------------------------------------------
# CREATE TABLE IF NOT EXISTS `courtautomation`.`backend_courtsection` (
#   `courtSectionId` INT NOT NULL AUTO_INCREMENT,
#   `sectionName` VARCHAR(100) NOT NULL,
#   `sectionType` VARCHAR(20) NOT NULL,
#   `fansCapacity` INT NOT NULL,
#   `courtId_id` INT NOT NULL,
#   PRIMARY KEY (`courtSectionId`),
#   INDEX `backend_courtsection_courtId_id_d0fcbea9_fk` (`courtId_id` ASC) VISIBLE,
#   CONSTRAINT `backend_courtsection_courtId_id_d0fcbea9_fk`
#     FOREIGN KEY (`courtId_id`)
#     REFERENCES `courtautomation`.`backend_court` (`courtId`))
# ENGINE = InnoDB
# DEFAULT CHARACTER SET = utf8mb4
# COLLATE = utf8mb4_0900_ai_ci;


# -- -----------------------------------------------------
# -- Table `courtautomation`.`backend_dealer`
# -- -----------------------------------------------------
# CREATE TABLE IF NOT EXISTS `courtautomation`.`backend_dealer` (
#   `dealer_id` INT NOT NULL AUTO_INCREMENT,
#   `name` VARCHAR(100) NOT NULL,
#   `address` VARCHAR(200) NOT NULL,
#   `contact_info` VARCHAR(100) NOT NULL,
#   `marginOfProfit` DOUBLE NOT NULL,
#   PRIMARY KEY (`dealer_id`))
# ENGINE = InnoDB
# DEFAULT CHARACTER SET = utf8mb4
# COLLATE = utf8mb4_0900_ai_ci;


# -- -----------------------------------------------------
# -- Table `courtautomation`.`backend_vendingmachine`
# -- -----------------------------------------------------
# CREATE TABLE IF NOT EXISTS `courtautomation`.`backend_vendingmachine` (
#   `vendingMachineId` INT NOT NULL AUTO_INCREMENT,
#   `courtSectionId_id` INT NOT NULL,
#   PRIMARY KEY (`vendingMachineId`),
#   INDEX `backend_vendingmachine_courtSectionId_id_84a1a63e_fk` (`courtSectionId_id` ASC) VISIBLE,
#   CONSTRAINT `backend_vendingmachine_courtSectionId_id_84a1a63e_fk`
#     FOREIGN KEY (`courtSectionId_id`)
#     REFERENCES `courtautomation`.`backend_courtsection` (`courtSectionId`))
# ENGINE = InnoDB
# DEFAULT CHARACTER SET = utf8mb4
# COLLATE = utf8mb4_0900_ai_ci;


# -- -----------------------------------------------------
# -- Table `courtautomation`.`backend_food`
# -- -----------------------------------------------------
# CREATE TABLE IF NOT EXISTS `courtautomation`.`backend_food` (
#   `foodId` INT NOT NULL AUTO_INCREMENT,
#   `name` VARCHAR(100) NOT NULL,
#   `description` LONGTEXT NOT NULL,
#   `unitPrice` DECIMAL(10,2) NOT NULL,
#   `quantity` INT NOT NULL,
#   `Maxquantity` INT NOT NULL,
#   `vendingMachineId_id` INT NULL DEFAULT NULL,
#   `dealer_id_id` INT NULL DEFAULT NULL,
#   PRIMARY KEY (`foodId`),
#   INDEX `backend_food_vendingMachineId_id_b5f55886_fk` (`vendingMachineId_id` ASC) VISIBLE,
#   INDEX `backend_food_dealer_id_id_7b48cf20_fk_backend_dealer_dealer_id` (`dealer_id_id` ASC) VISIBLE,
#   CONSTRAINT `backend_food_dealer_id_id_7b48cf20_fk_backend_dealer_dealer_id`
#     FOREIGN KEY (`dealer_id_id`)
#     REFERENCES `courtautomation`.`backend_dealer` (`dealer_id`),
#   CONSTRAINT `backend_food_vendingMachineId_id_b5f55886_fk`
#     FOREIGN KEY (`vendingMachineId_id`)
#     REFERENCES `courtautomation`.`backend_vendingmachine` (`vendingMachineId`))
# ENGINE = InnoDB
# DEFAULT CHARACTER SET = utf8mb4
# COLLATE = utf8mb4_0900_ai_ci;


# -- -----------------------------------------------------
# -- Table `courtautomation`.`backend_reservation`
# -- -----------------------------------------------------
# CREATE TABLE IF NOT EXISTS `courtautomation`.`backend_reservation` (
#   `reservationID` INT NOT NULL AUTO_INCREMENT,
#   `date` DATE NOT NULL,
#   `startTime` TIME NOT NULL,
#   `endTime` TIME NOT NULL,
#   `clientId_id` INT NULL DEFAULT NULL,
#   `courtsectionID_id` INT NULL DEFAULT NULL,
#   `token` VARCHAR(100) NULL DEFAULT NULL,
#   PRIMARY KEY (`reservationID`),
#   INDEX `backend_reservation_clientId_id_937add1b_fk_backend_c` (`clientId_id` ASC) VISIBLE,
#   INDEX `backend_reservation_courtsectionID_id_e3efbf18_fk_backend_c` (`courtsectionID_id` ASC) VISIBLE,
#   CONSTRAINT `backend_reservation_clientId_id_937add1b_fk_backend_c`
#     FOREIGN KEY (`clientId_id`)
#     REFERENCES `courtautomation`.`backend_client` (`clientId`),
#   CONSTRAINT `backend_reservation_courtsectionID_id_e3efbf18_fk_backend_c`
#     FOREIGN KEY (`courtsectionID_id`)
#     REFERENCES `courtautomation`.`backend_courtsection` (`courtSectionId`))
# ENGINE = InnoDB
# DEFAULT CHARACTER SET = utf8mb4
# COLLATE = utf8mb4_0900_ai_ci;


# -- -----------------------------------------------------
# -- Table `courtautomation`.`backend_foodpurchase`
# -- -----------------------------------------------------
# CREATE TABLE IF NOT EXISTS `courtautomation`.`backend_foodpurchase` (
#   `purchaseId` INT NOT NULL AUTO_INCREMENT,
#   `quantity` INT NOT NULL,
#   `foodId_id` INT NULL DEFAULT NULL,
#   `reservationId_id` INT NULL DEFAULT NULL,
#   PRIMARY KEY (`purchaseId`),
#   INDEX `backend_foodpurchase_foodId_id_86bfc10f_fk_backend_food_foodId` (`foodId_id` ASC) VISIBLE,
#   INDEX `backend_foodpurchase_reservationId_id_825dad4a_fk` (`reservationId_id` ASC) VISIBLE,
#   CONSTRAINT `backend_foodpurchase_foodId_id_86bfc10f_fk_backend_food_foodId`
#     FOREIGN KEY (`foodId_id`)
#     REFERENCES `courtautomation`.`backend_food` (`foodId`),
#   CONSTRAINT `backend_foodpurchase_reservationId_id_825dad4a_fk`
#     FOREIGN KEY (`reservationId_id`)
#     REFERENCES `courtautomation`.`backend_reservation` (`reservationID`))
# ENGINE = InnoDB
# DEFAULT CHARACTER SET = utf8mb4
# COLLATE = utf8mb4_0900_ai_ci;


# -- -----------------------------------------------------
# -- Table `courtautomation`.`backend_inventorysports`
# -- -----------------------------------------------------
# CREATE TABLE IF NOT EXISTS `courtautomation`.`backend_inventorysports` (
#   `inventoryId` INT NOT NULL AUTO_INCREMENT,
#   `itemName` VARCHAR(100) NOT NULL,
#   `unitPrice_hour` DECIMAL(10,2) NOT NULL,
#   `quantity` INT NOT NULL,
#   `typeChoices` VARCHAR(20) NULL DEFAULT NULL,
#   PRIMARY KEY (`inventoryId`))
# ENGINE = InnoDB
# DEFAULT CHARACTER SET = utf8mb4
# COLLATE = utf8mb4_0900_ai_ci;


# -- -----------------------------------------------------
# -- Table `courtautomation`.`backend_inventoryrent`
# -- -----------------------------------------------------
# CREATE TABLE IF NOT EXISTS `courtautomation`.`backend_inventoryrent` (
#   `inventoryRentId` INT NOT NULL AUTO_INCREMENT,
#   `inventoryId_id` INT NULL DEFAULT NULL,
#   `reservationId_id` INT NULL DEFAULT NULL,
#   PRIMARY KEY (`inventoryRentId`),
#   INDEX `backend_inventoryrent_inventoryId_id_d7e543a0_fk` (`inventoryId_id` ASC) VISIBLE,
#   INDEX `backend_inventoryrent_reservationId_id_2152527e_fk` (`reservationId_id` ASC) VISIBLE,
#   CONSTRAINT `backend_inventoryrent_inventoryId_id_d7e543a0_fk`
#     FOREIGN KEY (`inventoryId_id`)
#     REFERENCES `courtautomation`.`backend_inventorysports` (`inventoryId`),
#   CONSTRAINT `backend_inventoryrent_reservationId_id_2152527e_fk`
#     FOREIGN KEY (`reservationId_id`)
#     REFERENCES `courtautomation`.`backend_reservation` (`reservationID`))
# ENGINE = InnoDB
# DEFAULT CHARACTER SET = utf8mb4
# COLLATE = utf8mb4_0900_ai_ci;


# SET SQL_MODE=@OLD_SQL_MODE;
# SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
# SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
