grades=[]
for i in range(1,6):
    a=int(input("Enter the grade of student:"))
    grades.append(a)
print("All Grades:",grades)
print("Minimum Grade:",min(grades))
print("Maximum Grade:",max(grades))
print("Average Grade:",(sum(grades)/5))
