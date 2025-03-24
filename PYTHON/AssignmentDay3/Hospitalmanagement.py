doctors=[(1,"Dr.Aryan Raj Singh Rathore","OPD"),(2,"Dr.Meenu Verma","Bones"),(3,"Dr.Atishay Jain","Operation"),(4,"Dr.Aditya Singhal","FACE")]
patient={}
def register():
    name=input("Enter your name:")
    age=input("Enter your age:")
    disease=input("Enter your disease:")
    return (name,age,disease)
def availabledoctors(view):
    print(view)
def bookappointmemnt(n,register):
    name,age,disease=register()
    print("Available doctors for appointment:",n)
    idd=int(input("Enter doctor id:"))
    patient[name]=doctors[idd-1]
    doctors.pop(idd-1  )
    print("Booking Done")
def history():
    if not patient:
        print("NO HISTORY")
    else:
        print(patient)
while True:
    print("Welcome to hospital")
    print("1)Register a new patient\n","2)Available Doctors\n","3)BookAppointmnet\n","4)Appointment History\n","5)Exit")
    choice=int(input("Enter your choice:"))
    if choice==1:
        register()
    elif choice==2:
        availabledoctors(doctors)
    elif choice==3:
        bookappointmemnt(doctors,register)
    elif cehoice==4:
        history()
    elif choice==5:
        break
    else:
        print("Invalid Choice")