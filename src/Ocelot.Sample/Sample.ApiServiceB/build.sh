#!/bin/bash

echo Linux Docker 

docker build -t api.b .

docker run  -d -p 5002:5002 -e "ASPNETCORE_URLS=http://+:5002" api.b