import pretty_errors
from django.contrib.auth.hashers import make_password  # for password hashing
import random
from backend.models import Admin, Court, CourtSection, Dealer, VendingMachine, Food, Client, Reservation, FoodPurchase, InventorySports,InventoryRent
from django.core.exceptions import ValidationError  # for handling potential quantity errors
from datetime import time
from phonenumber_field.phonenumber import PhoneNumber
from datetime import datetime, timedelta

def create_admin():
    """Creates an admin user with specified details."""
    try:
        
        defaults = {
            'username': "charbel",
            'password': make_password("daher"),  # Replace with a stronger password
            'email': "charbeldaher34@gmail.com",
        }
        admin, created = Admin.objects.get_or_create(**defaults)
    except:
        admin=Admin.objects.get(email="charbeldaher34@gmail.com")

    return admin


def create_court(admin):
    """Creates a court with a name, location, and assigns the provided admin."""
    court = Court.objects.create(
        name="Riyadi Club",
        location="Ferzoul",
        adminId=admin,
    )
    return court


def create_court_sections(court):
    """Creates three court sections with different types for the given court."""
    
    section_types = ["basketball", "football", "tennis"]
    for section_type in section_types:
        CourtSection.objects.create(
            courtId=court,
            sectionName=f"Section {section_type}",
            sectionType=section_type,
            fansCapacity=500,
            openTime=time(9,0),
            closeTime=time(22,0)
            
        )


def create_vending_machine(court_section):
  """Creates a vending machine associated with the provided court section."""
  vending_machine = VendingMachine.objects.create(courtSectionId=court_section)
  return vending_machine

def create_dealer(name, address, contact_info, margin_of_profit):
    """Creates a dealer with specified details."""
    if margin_of_profit < 0:
      raise ValidationError("Margin of profit cannot be negative.")
    return Dealer.objects.create(
        name=name,
        address=address,
        contact_info=contact_info,
        marginOfProfit=margin_of_profit,
    )

def create_food(name, description, unit_price, quantity, max_quantity, vending_machine=None, dealer=None):
  """Creates a food item with details and optional associations."""
  if quantity > max_quantity:
    raise ValidationError("Quantity cannot be greater than max quantity.")
  food = Food.objects.create(
      name=name,
      description=description,
      unitPrice=unit_price,
      quantity=quantity,
      Maxquantity=max_quantity,
      vendingMachineId=vending_machine,
      dealer_id=dealer,
  )
  return food


def create_three_dealers():
    dealers = []
    try:
        dealers.extend(
            (
                Dealer.objects.create(
                    name="Dealer 1",
                    address="Address 1",
                    contact_info="Contact Info 1",
                    marginOfProfit=0.1,
                ),
                Dealer.objects.create(
                    name="Dealer 2",
                    address="Address 2",
                    contact_info="Contact Info 2",
                    marginOfProfit=0.15,
                ),
                Dealer.objects.create(
                    name="Dealer 3",
                    address="Address 3",
                    contact_info="Contact Info 3",
                    marginOfProfit=0.2,
                ),
            )
        )
    except ValidationError as e:
        print(f"Error creating dealer: {e}")
    return dealers




def create_client(first_name, last_name, email, password, phone_number=None, address=None, country=None, date_of_birth=None, sex=None):
    if not email:
        raise ValidationError("Email address is required.")

    try:
        # Attempt to create the client with unique email validation
        client = Client.objects.create(
            firstName=first_name,
            lastName=last_name,
            email=email,
            password=password,  # Add password field
            number=phone_number,
            address=address,
            country=country,
            date_of_birth=date_of_birth,
            sex=sex,
        )
    except Exception as e:  # Catch potential duplicate email errors
        if "unique" in str(e):  # Check if error is related to unique email
            raise ValidationError("Email address must be unique.")
        else:
            raise e  # Re-raise other exceptions

    return client


def create_random_client():

    first_name = "Charbel"
    last_name = "Daher"
    email = "charbeldaher345@gmail.com"
    password = "Daher1234"  # Generate a random password
    phone_number = PhoneNumber.from_string("+96170435237")
    country = "LB"  # Set country to Lebanon
    lebanon_cities = [
        "Beirut", "Tripoli", "Sidon", "Tyre", "Byblos", "Jounieh", "Baabda", "Zahle", "Baalbek", "Batroun",
        "Nabatieh", "Zgharta", "Bsharri", "Aley", "Chouf", "Bint Jbeil", "Marjaayoun", "Hasbaya", "Rashaya",
        "Hermel", "Akkar", "Bekaa", "Keserwan", "Metn"
    ]

    address = random.choice(lebanon_cities)
    date_of_birth = "2002-01-1"  # Random date
    sex = random.choice(['M', 'F'])

    return create_client(first_name, last_name, email, password, phone_number, address, country, date_of_birth, sex)




def create_reservations():
    # Example parameters for reservations
    reservations_data = [
        {
            'clientId': Client.objects.get(clientId=1),  # Assuming client ID is 1
            'courtsectionID': CourtSection.objects.get(courtSectionId=1),  # Assuming court section ID is 1
            'date': datetime.now().date(),  # Today's date
            'startTime': datetime.now().time(),  # Current time
            'endTime': (datetime.now() + timedelta(hours=2)).time(),  # One hour later
            'token': 'example_token1'  # Example token
        },
        {
            'clientId': Client.objects.get(clientId=1),  # Assuming client ID is 1
            'courtsectionID': CourtSection.objects.get(courtSectionId=1),  # Assuming court section ID is 2
            'date': datetime.now().date(),  # Tomorrow's date
            'startTime': (datetime.now()+ timedelta(hours=4)).time(),  # Current time
            'endTime': (datetime.now() + timedelta(hours=6)).time(),  # One hour later
            'token': 'example_token2'  # Example token
        },
        # Add more reservation data as needed
    ]

    # Create reservations
    for data in reservations_data:
        reservation = Reservation.objects.create(**data)
        print(f"Reservation created: {reservation}")

# Call the function to create reservations



class MySeeder(object):
    def run(self):
        """Executes the seeder functions in the desired order."""
        admin = create_admin()
        court = create_court(admin)
        court_ids = Court.objects.values_list('courtId', flat=True)
        for courtId in court_ids:
            create_court_sections(Court.objects.get(courtId=courtId))


        for courtId in court_ids:
            court_sections=CourtSection.objects.filter(courtId=courtId)
            for cs in court_sections:
                create_vending_machine(cs)
        create_three_dealers()

        vms=VendingMachine.objects.all()

        for vm in vms:
            

            random_name = f"Food {random.randint(1, 100)}"
            random_description = f"Random description {random.randint(1, 100)}"
            random_unit_price = round(random.uniform(0.5, 10.0), 2)
            random_quantity = random.randint(1, 100)
            random_max_quantity = random.randint(random_quantity, 200)

            dealer=Dealer.objects.first()

# Call the function with random inputs
            create_food(random_name, random_description, random_unit_price, random_quantity, random_max_quantity,vm,dealer)
        create_random_client()
        create_reservations()

        



