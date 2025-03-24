#Q.3 module
import re
import datetime

def validate_destination(destination):
    if not re.match("^[A-Za-z ]+$", destination):
        raise ValueError("Destination name must contain only letters and spaces.")
    return True

def validate_dates(start_date, end_date):
    if start_date > end_date:
        raise ValueError("Start date cannot be after the end date.")
    return True

def is_trip_in_next_7_days(start_date):
    return datetime.datetime.now() <= start_date <= datetime.datetime.now() + datetime.timedelta(days=7)

def is_overlapping(itinerary1, itinerary2):
    if itinerary1.start_date < itinerary2.end_date and itinerary1.end_date > itinerary2.start_date:
        return True
    return False
