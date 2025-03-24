books={}
numb=int(input("Enter Number of books to be inputed:"))
while len(books)!=numb:
    bookid=int(input("Enter book id:"))
    if bookid not in books:

        booktitle=input("Enter the book title:")
        books[bookid]=booktitle
    else:
        print("Invalid or Duplicate ID")
while True:
    print("1)Display All Books\n","2)Search For Book\n","3)Exit")

    choice=int(input("Enter Your Choice:"))
    if choice==2:
        idd=int(input("Enter book id to retrieve information:"))
        print(books[idd])
    elif choice==1:
        print("All available books:",books)
    elif choice==3:
        break