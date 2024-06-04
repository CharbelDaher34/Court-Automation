from faker import Faker
from datetime import datetime, timedelta, time
import random
import mysql.connector
import logging

def generate_reservations(nb_rows, cursor):
    fake = Faker()
    
    # Fetch client IDs
    cursor.execute("SELECT clientId FROM backend_client")
    client_ids = [row[0] for row in cursor.fetchall()]

    # Fetch court section IDs
    cursor.execute("SELECT courtSectionId FROM backend_courtsection")
    courtsection_ids = [row[0] for row in cursor.fetchall()]

    # Define time ranges for start times (every 1.5 hours from 9 AM to 8:30 PM)
    start_time_range = [
        time(hour=9, minute=0), time(hour=10, minute=30), time(hour=12, minute=0),
        time(hour=13, minute=30), time(hour=15, minute=0), time(hour=16, minute=30),
        time(hour=18, minute=0), time(hour=19, minute=30)
    ]
    
    for _ in range(nb_rows):
        start_date = datetime.strptime('2020-01-01', '%Y-%m-%d').date()
        end_date = datetime.strptime('2023-12-31', '%Y-%m-%d').date()
        date = fake.date_between(start_date=start_date, end_date=end_date)
        
        start_time = random.choice(start_time_range)
        # Calculate end time by adding 1.5 hours to start time
        end_time = (datetime.combine(date, start_time) + timedelta(minutes=90)).time()

        # Check for overlapping reservations in the same court section and date
        query = """
        SELECT COUNT(*) 
        FROM backend_reservation 
        WHERE courtsectionID_id = %s 
        AND date = %s 
        AND NOT (endTime <= %s OR startTime >= %s)
        """
        cursor.execute(query, (random.choice(courtsection_ids), date, start_time, end_time))
        count = cursor.fetchone()[0]

        if count == 0:
            data = {
                'date': date,
                'startTime': start_time,
                'endTime': end_time,
                'token': str(fake.random_number(digits=10)),
                'clientId_id': random.choice(client_ids),
                'courtsectionID_id': random.choice(courtsection_ids)
            }
            
            columns = ', '.join(data.keys())
            values_template = ', '.join(['%s'] * len(data))
            query = f"INSERT INTO backend_reservation ({columns}) VALUES ({values_template})"

            values = tuple(data.values())
            try:
                cursor.execute(query, values)
            except Exception as e:
                logging.exception('Error while inserting reservations')

# Main execution
mysql_conn = mysql.connector.connect(
    host="localhost",
    user="root",
    password="a",
    database="courtautomation"
)

cursor = mysql_conn.cursor()
generate_reservations(200, cursor)  # Generate 50 reservations
mysql_conn.commit()
cursor.close()
mysql_conn.close()
