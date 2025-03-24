booked={}
cars={1:(1,"BMW",12000),2:(2,"AUDI",10000),3:(3,"Alto800",2000)}
def displaycars(n):
    print(n)
def rentcar(c):
    idd=int(input("Enter the car ID:"))
    print(c[idd])
    rent=int(input("Enter the days you want to rent:"))
    if rent<=0:
        print("Days must be at least 1")
    else:
        print("Total Price for renting this car:",(cars[idd][1])*rent)
        booked[idd]=c[idd]
        cars.pop(idd)
    return (idd,rent)
def viewbookedcar(b):
    print(b)
def invoice(a,b):
    if not booked:
        print("You have not booked any car")
    else:
        print("Car you rented:",booked[a],"Total Amount you paid:",b*(booked[a][2]),"For",b,"Days")
    
def returnacar(boo,car):
    idd=int(input("Enter the card ID:"))
    if not booked:
        print("No Booked Cars")
    else:
        cars[idd]=boo[idd]
        booked.pop(idd)
        print("Thankyou For Returning")

while True:
    print("1)Display All Available Cars\n","2)Rent a car\n","3)View booked Car\n","4)Invoice\n","5)Return the car\n","6)Exit")
    choice=int(input("Enter your Choice:"))
    if choice==1:
        displaycars(cars)
    elif choice==2:
        a,b=rentcar(cars)
    elif choice==3:
        viewbookedcar(booked)
    elif choice==4:
        invoice(a,b)
    elif choice==5:
        returnacar(booked,cars)
    elif choice==6:
        break
    else:
        print("Invalid choice")