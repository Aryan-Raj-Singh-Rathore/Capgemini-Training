class database:
    def __init__(self):
        self.users={}
    def add_user(self,user_id,name):
        if user_id in self.users:
            print("User Already registered")        #Debugging Print
            raise ValueError("User Aleady Exists")
        self.users[user_id]=name
        print("User Added Successfully")                #Debugging Print

    def get_user(self,user_id):
        return self.users[user_id]