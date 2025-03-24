#Q.2 module
import re
import datetime

def validate_password(password):
    if len(password) < 8:
        raise ValueError("Password must be at least 8 characters long.")
    if not re.search(r"[A-Z]", password):
        raise ValueError("Password must contain at least one uppercase letter.")
    if not re.search(r"[a-z]", password):
        raise ValueError("Password must contain at least one lowercase letter.")
    if not re.search(r"[0-9]", password):
        raise ValueError("Password must contain at least one digit.")
    if not re.search(r"[@$!%*?&]", password):
        raise ValueError("Password must contain at least one special character.")
    return True

def encrypt(password):
    return password  

def password_old(last_updated):
    return (datetime.datetime.now() - last_updated).days > 90
