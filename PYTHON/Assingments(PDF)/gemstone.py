gems_available=["Diamond","Ruby","Topaz","Emarled"]
available_quantity=[]
price=[5000,3000,8000,4900]

gems_required=["Diamond","Topaz"]
quantity=[3,5]

total_amount=0.0
 
for i in gems_required:
    if i not in gems_available:
        total_amount= -1
    else:
        total_amount=total_amount+price[gems_available.index(i)]*quantity[gems_required.index(i)]
                
        
if total_amount>=30000:
    total_amount=total_amount-(total_amount*0.05)
    print(total_amount)
else:
    print(total_amount)