from integrationTesting import database
class userservice:
    def __init__(self,db):
        self.db=db      #dependency Injection
    def register_user(self,user_id,name):
        self.db.add_user(user_id,name)
    def fetch_user(self,user_id):
        return self.db.get_user(user_id)