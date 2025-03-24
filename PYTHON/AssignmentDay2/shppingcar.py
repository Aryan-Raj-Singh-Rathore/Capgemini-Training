cart={}
while True:
    print("1)Add items:\n","2)View Cart:\n","3)Calculate the total bill:\n","4)Exit")
    choice=int(input("Enter Your Choice:"))
    if choice==1:
        item=input("Enter the item you want to add:")
        price=float(input("Enter the price of the item:"))
        cart[item]=price
    elif choice==2:
        if not cart:
            print("Cart is empty")
        else:
            print(cart)
    elif choice==3:
        total=sum(cart.values())
        print(total)
    else:
        print("Thankyou for visiting")
        break