balance=0
balance1=0
username1="aryanrajsinghrathore.it25@gmail.com"
password1=12345
username2="aryan.it25@gmail.com"
password2=6789
while True:
    print("Welcome to My application")
    user=input("Enter your username:")
    idd=int(input("Enter your password:"))
    if (username1==user and password1==idd) or (username2==user and password2==idd):
        while True:
            print("1) Deposite\n","2) Withdrwal\n","3) Balance Display\n","4) Exit\n ","5)Online Transfer")
            choice=int(input("Enter your choice:"))
            if choice==1:
                a=int(input("Enter Amount to be deposited:"))
                balance=balance+a
                print("Amount Deposited")
            elif choice==2:
                if balance>0:
                    b=int(input("Enter amount to be withdrawled:"))
                    if b<balance:
                        balance=balance-b
                        print("DONE")
                    else:
                        print("Can not be done")
                else:
                    print("Insufficient balance")
            elif choice==3:
                if user==username2:
                    print("Your balance is:",balance1)
                else:
                    print("Your balance is:",balance)
            elif choice==5:
                if balance>0:
                    d=input("Enter ID for Transfering Money:")
                    c=int(input("Enter amount to be transferred:"))
                    if d == username2:
                        if c<balance:
                            balance=balance-c
                            balance1=balance1+c
                            print("Payment Successfull",balance,"is remaining balance")
                        else:
                            print("Invalid Request")
                    else:
                        print("Invalid")
            else:
                print("Thankyou")
                break
    else:
        print("Invalid Password")