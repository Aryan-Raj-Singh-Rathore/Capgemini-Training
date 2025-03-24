#Q.2 Advanced Password Manager
import pickle
import os
import datetime
from moduleFOR2 import validate_password, encrypt, password_old

class PasswordEntry:
    def __init__(self, website, username, password):
        self.website = website
        self.username = username
        self.password = password
        self.last_updated = datetime.datetime.now()

    def __str__(self):
        return f"Website: {self.website}, Username: {self.username}, Last Updated: {self.last_updated}"

class PasswordManager:
    def __init__(self):
        self.entries = []
    
    def add_entry(self):
        try:
            website = input("Enter website: ")
            username = input("Enter username: ")
            password = input("Enter password: ")

            # Validate the password
            if validate_password(password):
                password = password(password)  # Encrypt the password (just returns password here)
                entry = PasswordEntry(website, username, password)
                self.entries.append(entry)
                print("Password entry added successfully.")
        except ValueError as e:
            print(f"Error: {e}")

    def remove_entry(self):
        website = input("Enter website to remove: ")
        for entry in self.entries:
            if entry.website == website:
                self.entries.remove(entry)
                print("Entry removed successfully.")
                return
        print("No entry found for that website.")
    
    def display_entries(self):
        for entry in self.entries:
            print(entry)

    def get_old_entries(self):
        for entry in self.entries:
            if password_old(entry.last_updated):
                yield entry

    def save_entries(self):
        try:
            with open("passwords.pkl", "wb") as f:
                pickle.dump(self.entries, f)
            print("Entries saved successfully.")
        except Exception as e:
            print(f"Error saving file: {e}")
    
    def load_entries(self):
        if os.path.exists("passwords.pkl"):
            try:
                with open("passwords.pkl", "rb") as f:
                    self.entries = pickle.load(f)
                print("Entries loaded successfully.")
            except Exception as e:
                print(f"Error loading file: {e}")
        else:
            print("No saved entries found.")


manager = PasswordManager()

print("1. Add a password entry")
print("2. Remove a password entry")
print("3. Display all password entries")
print("4. Display old password entries (more than 90 days)")
print("5. Save password entries to file")
print("6. Load password entries from file")
print("7. Exit")

while True:
    choice = input("Enter your choice: ")

    if choice == "1":
        manager.add_entry()
    elif choice == "2":
        manager.remove_entry()
    elif choice == "3":
        manager.display_entries()
    elif choice == "4":
        old_entries = manager.get_old_entries()
        for entry in old_entries:
            print(entry)
    elif choice == "5":
        manager.save_entries()
    elif choice == "6":
        manager.load_entries()
    elif choice == "7":
        break
    else:
        print("Invalid choice. Please try again.")


