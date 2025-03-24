from django.urls import path
from .views import hello_world
urlpatter=[
    path('',hello_world),
]