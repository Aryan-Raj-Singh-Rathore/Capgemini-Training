
emp={}
ttl=int(input("Enter number of employee:"))
while len(emp)!=ttl:

    empid=int(input("Enter Your Employee ID:"))
    if empid not in emp:
        name=(input("Enter Your Name:"),)
        salary=(int(input("Enter your salary:")),)
        emp[empid]=name+salary
    else:
        print("Invalid or Duplicate ID")
idd=int(input("Enter the id to retrive information:"))
print(emp[idd])