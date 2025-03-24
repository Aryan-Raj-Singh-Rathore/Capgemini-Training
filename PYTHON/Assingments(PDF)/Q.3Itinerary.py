#Q.3 Advanced Travel Itinerary Planner
import pickle
import os
import datetime
from moduleFOR3 import validate_destination, validate_dates, is_trip_in_next_7_days, is_overlapping

class Itinerary:
    def __init__(self, itinerary_id, destination, start_date, end_date):
        self.itinerary_id = itinerary_id
        self.destination = destination
        self.start_date = start_date
        self.end_date = end_date

    def __str__(self):
        return f"ID: {self.itinerary_id}, Destination: {self.destination}, Start Date: {self.start_date}, End Date: {self.end_date}"

class TravelItineraryPlanner:
    def __init__(self):
        self.itineraries = []

    def add_itinerary(self):
        try:
            itinerary_id = input("Enter itinerary ID: ")
            destination = input("Enter destination: ")
            if validate_destination(destination):
                start_date_str = input("Enter start date (yyyy-mm-dd): ")
                end_date_str = input("Enter end date (yyyy-mm-dd): ")
                
                start_date = datetime.datetime.strptime(start_date_str, "%Y-%m-%d")
                end_date = datetime.datetime.strptime(end_date_str, "%Y-%m-%d")
                
                if validate_dates(start_date, end_date):
                    for itinerary in self.itineraries:
                        if is_overlapping(itinerary, Itinerary(itinerary_id, destination, start_date, end_date)):
                            raise ValueError("The itinerary overlaps with an existing one.")
                    itinerary = Itinerary(itinerary_id, destination, start_date, end_date)
                    self.itineraries.append(itinerary)
                    print("Itinerary added successfully.")
        except ValueError as e:
            print(f"Error: {e}")

    def display_itineraries(self):
        for itinerary in self.itineraries:
            print(itinerary)

    def get_itineraries_in_next_7_days(self):
        for itinerary in self.itineraries:
            if is_trip_in_next_7_days(itinerary.start_date):
                yield itinerary

    def save_itineraries(self):
        try:
            with open("itineraries.pkl", "wb") as f:
                pickle.dump(self.itineraries, f)
            print("Itineraries saved successfully.")
        except Exception as e:
            print(f"Error saving file: {e}")

    def load_itineraries(self):
        if os.path.exists("itineraries.pkl"):
            try:
                with open("itineraries.pkl", "rb") as f:
                    self.itineraries = pickle.load(f)
                print("Itineraries loaded successfully.")
            except Exception as e:
                print(f"Error loading file: {e}")
        else:
            print("No saved itineraries found.")

def main():
    planner = TravelItineraryPlanner()

    print("1. Add an itinerary")
    print("2. Display all itineraries")
    print("3. Display itineraries starting in the next 7 days")
    print("4. Save itineraries to file")
    print("5. Load itineraries from file")
    print("6. Exit")

    while True:
        choice = input("Enter your choice: ")

        if choice == "1":
            planner.add_itinerary()
        elif choice == "2":
            planner.display_itineraries()
        elif choice == "3":
            itineraries = planner.get_itineraries_in_next_7_days()
            for itinerary in itineraries:
                print(itinerary)
        elif choice == "4":
            planner.save_itineraries()
        elif choice == "5":
            planner.load_itineraries()
        elif choice == "6":
            break
        else:
            print("Invalid choice. Please try again.")

if __name__ == "__main__":
    main()
