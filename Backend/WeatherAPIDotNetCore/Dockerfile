# Our base build image
FROM microsoft/dotnet:2.2-sdk AS build-env

# Create and change directory
WORKDIR /app

# Copy the project files
COPY /Backend/WeatherAPIDotNetCore/WeatherAPI /WeatherAPI
COPY /Backend/WeatherAPIDotNetCore/WeatherCore /WeatherCore
COPY /Backend/WeatherAPIDotNetCore/WeatherData /WeatherData

# Create and change directory
WORKDIR /WeatherAPI

#Restores the dependencies 
RUN dotnet restore 

# build image for release
 FROM build-env AS publish
 RUN dotnet publish -c Release -o /WeatherAPI

# our final base image
FROM microsoft/dotnet:2.2-aspnetcore-runtime

#Set Author and Maintainer of project(OPTIONAL)
LABEL Author="Akhil S"
LABEL docker Maintainer="weatherman"

# copy over the built 
COPY --from=publish /WeatherAPI .

# set the startup command to run  binary
ENTRYPOINT ["dotnet", "WeatherAPI.dll", "--server.urls", "http://*:5000"]