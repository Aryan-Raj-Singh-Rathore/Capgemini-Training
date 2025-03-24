booked={}
cars={1:("BMW",12000),2:("AUDI",10000),3:("Alto800",2000)}
while True:
    
    car={1:("BMW",12000),2:("AUDI",10000),3:("Alto800",2000)}
    print("1)Display All Available Cars\n","2)Rent a car\n","3)View booked Car\n","4)Invoice\n","5)Return the car\n","6)Exit")
    choice=int(input("Enter your Choice:"))
    if choice==1:
        print(cars)
    elif choice==2:
        idd=int(input("Enter the car ID:"))
        print(cars[idd])
        rent=int(input("Enter the days you want to rent:"))
        if rent<=0:
            print("Days must be at least 1")
        else:
            print("Total Price for renting this car:",(cars[idd][1])*rent)
            booked[idd]=cars[idd]
            cars.pop(idd)
    elif choice==3:
        print(booked)
    elif choice==4:
        print("Car you rented:",car[idd],"Total Amount you paid:",rent*(car[idd][1]),"For",rent,"Days")
    elif choice==5:
        print("Thankyou for return the car")
        cars[idd]=car[idd]
    else:
        print("Thankyou for visiting")
        break