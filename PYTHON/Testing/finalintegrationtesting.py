import unittest
from integrationTesting import database
from integrationTesting_userservice import userservice

class TestIntegration(unittest.TestCase):
    def setUp(self):
        self.db=database()
        self.service=userservice(self.db)
    def test_register_and_fetch_user(self):
        self.service.register_user(1,"Allice")
        self.assertEqual(self.service.fetch_user(1),"Allice")
    def test_register_duplicate_user(self):
        self.service.register_user(2,"Charlie")
        self.service.register_user(2,"Bob")         #Duplicate Id
    
unittest.main(argv=[''],exit=False,verbosity=2)
