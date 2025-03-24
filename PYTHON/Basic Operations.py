name=input("Enter Your name:")
age=int(input("Enter your age:"))
salary=float(input("Enter Salary:"))
bonus= salary*0.2
print("Bonus:",bonus)
print("Name:", name,"\nAge:",age,"\nSalary:", salary)

#SEPRATORS

print("Name:", name,"Age:",age,"Salary:", salary,sep="#")

#end

print("Name:", name,"Age:",age,"Salary:", salary,end="#")

#EVAL
number=eval(input("Enter the equation:"))
print(number)
