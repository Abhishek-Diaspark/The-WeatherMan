<h1 align="center">
  <br>
  <a><img src="https://github.com/Abhishek-Diaspark/The-WeatherMan/blob/master/Backend/WeatherAPIDotNetCore/docs/images/logo.png" alt="TheWeatherMan"></a>
  <br>
  The WeatherMan Application (Backend using DotNet Core)
  <br>
</h1>

<p align="center">
    <a alt="DotNet Core 2.2">
        <img src="https://img.shields.io/badge/DotNet Core-v2.2-orange.svg" />
    </a>
    <a alt="CosmosDB">
        <img src="https://img.shields.io/badge/Cosmos DB-v2.1.3-brightgreen.svg" />
    </a> 
    <a alt="Redis Cache">
        <img src="https://img.shields.io/badge/Redis Cache-v4.0-brightgreen.svg" />
    </a> 
    <a alt="Docker">
        <img src="https://img.shields.io/badge/Docker-v18-yellowgreen.svg" />
    </a>
    <a alt="Dependencies">
        <img src="https://img.shields.io/badge/dependencies-up%20to%20date-brightgreen.svg" />
    </a>
    <a alt="Contributions">
        <img src="https://img.shields.io/badge/contributions-welcome-orange.svg" />
    </a>
    <a alt="License">
        <img src="https://img.shields.io/badge/license-MIT-blue.svg" />
    </a>
</p>

## Table of Contents ##
1. [DotNet Core](#DotNet-Core)
2. [Application](#Application)
3. [Database Schema](#Database-Schema)
4. [Technology](#Technology)
5. [Application Structure](#Application-Structure)
6. [Run Locally](#Running-the-server-locally)
7. [Run Insider Docker](#Running-the-server-in-Docker-Container)
8. [API Documentation](#API-Documentation)
9. [Contributors](#Contributors)
10. [License](#License)

## DotNet Core ##
DotNET Core is a free and open-source, managed computer software framework for Windows, Linux, and macOS operating systems. It is an open source, cross platform successor to .NET Framework. The project is primarily developed by Microsoft and released under the MIT License.

**Cross-platform & container support** : This simply means that dotnet core is able to be used on different types of computers or with different software packages.
Containers are a type of software that can virtually package and isolate applications for deployment. Containers can share access to an operating system (OS) kernel without the traditional need for virtual machines (VMs).

**Asynchronous via async/await** : This implies that that a process operates independently of other processes, whereas synchronous operation means that the process runs only as a result of some other process being completed or handing off operation.

**Unified MVC & Web API frameworks** : MVC is an application design model comprised of three interconnected parts. They include the model (data), the view (user interface), and the controller (processes that handle input).

Web API is an extensible framework for building HTTP based services that can be accessed in different applications on different platforms such as web, windows, mobile etc. It works more or less the same way as ASP.NET MVC web application except that it sends data as a response instead of html view.


## Application ##
What’s the weather? What will be tomorrow’s weather? These question are the ones which maximum people likes to know the answer on the daily basis and thus people wants to know the most accurate weather forecast. Their are many applications which gives the weather report and forecast but on which website user should rely on because every application shows different different data which makes user perplexed.

The WeatherMan Analysis shows approximate weather forecast of 5 days, on the basis of the analysis done on the data from four well known and authorized weather service providers, for the place which user selects and also weatherman checks and compares the last year data of that particular day and thus apply its analysis and predict the forecast.These two are the major factor of the weatherman analysis .The aim of the application is to give the most accurate weather information out of all the service providers.  :

## Database Schema ##
The current schema looks as follows:

<img src="https://github.com/Abhishek-Diaspark/The-WeatherMan/blob/master/Backend/WeatherAPIDotNetCore/docs/images/db-schema.jpg" alt="DotNet Core"></a>

- The authentication and authorization is governed by _User_ collection. (User model)
- The _Provider_ collection keeps the details of all the service providers which we are using. The 4 providers will also get   automatically added on app start. (Provider model)
- The _Vote_ collection keeps users' favorite option with date of voting and 2 foreign keys provider.id & user.id. (Vote model)

## Technology ##
Following libraries were used during the development of this starter kit :

- **DotNet Core 2.2** - Server side framework
- **Docker** - Containerizing framework
- **CosmosDB(MongoAPI)** - Database 
- **Swagger** - API documentation
- **JWT** - Authentication mechanism for REST APIs
- **Redis** - Caching data to save hits on Weather api's

## Application Structure ##
DotNET Core is a free and open-source, managed computer software framework for Windows, Linux, and macOS operating systems.DotNet core is provides the command line, which support all major platforms like Windows, Mac, and Linux.it provide variuos project template and ideology for faster and smooth app development.I have tried to follow the same ideology while creating the project structure, at first it might seem like overwhelming, but do believe me once you start writing your pieces the structure will help you immensely by saving your time and thinking about questions which are already answered. The structure look as follows :

<img src="https://miro.medium.com/max/330/1*_nwVbi3F0UxY-Vnus3tWZA.png" alt="project structure"></a>

ASP.Net core solution contains three projects as:

**_WeatherAPI_** 
This project holds the API part which provides a URI's  for other applications to communicate with core project. Thus, all controller related logic lies here.

**_WeatherCore_** 
This is our  intermediate layer and apply our business logic on the data that we get from various resources and supply it to our WeatheAPI project.

 **_WeatherData_** 
This is the third and inner most layer of our solution this layer deals with our project's interaction with data base server. It fetches the data and carry it forward to the middle layer.


**_Models_**

The various models of the application are organized under the **WeathrData** projectinside WeatherApiDotNetCore solution.In our application we are using model to repersent shape of the data and business logic of our application. 

**_Data Access layer_**

The data access layer (DAL) are present in the **_WeatherData_** project inside WeatherApiDotNetCore solution.A data access layer (DAL)  is a layer of a computer program which provides simplified access to data stored in persistent storage of some kind, such as database.In our program we have using DAL(Data access layer) to fetch weather data from various and weather reports provider.

**_Security_**

In our web application we have used JWT  securely transmitting information between parties as a JSON object.

**_Controllers_**

Last, but the most important part is the controller layer. It binds everything together right from the moment a request is intercepted till the response is prepared and sent back. The controller layer is present in the **_WeatherAPI_** project of WeatherAPIDotNetCore solution, the best practices suggest that we keep this layer versioned to support multiple versions of the application and the same practice is applied here. 

**_Service layer_**

A service layer is an additional layer in an ASP.NET MVC application that mediates communication between a controller and repository layer. The service layer contains business logic. In particular, it contains validation logic as well.

## Running the server locally ##
To be able to run this DotNet Core api you will need to first build it. To build and package a DotNet Core app into a single executable file dotnet core v2.2 sdk must be install on our local machine, use the below command. You will need to run it from the project folder which contain WeatherApi.csproj.

download DotNet SDK 2.2 from below link

https://dotnet.microsoft.com/download 

```
dotnet restore
```
Restores the dependencies and tools of a project.

```
dotnet build
```
Builds a project and all of its dependencies.

```
dotnet run
```
Runs source code without any explicit compile or launch commands.

You can follow any/all of the above commands, or simply use the run configuration provided by your favorite IDE and run/debug the app from there for development purposes. Once the server is setup you should be able to access the admin interface at the following URL :

http://localhost:5000

Some of the important api endpoints are as follows :

- http://localhost:5000/register (HTTP:POST)
- http://localhost:5000/authenticate (HTTP:POST)
- http://localhost:5000/averageprovider?lat=22.7196&longi=75.8577 (HTTP:GET)
- http://localhost:5000/summaryprovider (HTTP:GET)

## Running the server in Docker Container ##
##### Docker #####
Command to build the container :

```
docker build -t dotnet/theweatherman .
```

Command to run the container :

```
docker run -p 5000:80 dotnet/theweatherman
```

Please **note** when you build the container image and if Azure Cosmos DB is running locally on your system, you will need to   set Cosmos DB connection string to Enviroment variable as  COSMOS_DATABASE_NAME={COSMOS_DATABASE_NAME}  to be able to connect to the database from within the container.

## API Documentation ##
Its as important to document(as is the development) and make your APIs available in a readable manner for frontend teams or external consumers. The tool for API documentation used in this starter kit is Swagger2, you can open the same inside a browser at the following url -

http://localhost:5000/swagger/index.html

You can use the User spec to execute the login api for generating the Bearer token. The token then should be applied in the "Authorize" popup which will by default apply it to all secured apis (get and post both).

<p align="center">
    <b>Swagger</b><br>
    <br>
    <img width="600" src="https://github.com/Abhishek-Diaspark/The-WeatherMan/blob/master/Backend/WeatherAPIDotNetCore/docs/images/swagger.png">
</p>

We are enabling middleware for Swagger as a JSON endpoint in config() method of StarTup.cs file.
Register the Swagger generator by defining Swagger documents.

Note:By passing login authentication for time being database is not up and running.
     Please provide your custom login for login and register user.

## Contributors ##
[Abhishek Anand](https://www.linkedin.com/in/abhishek-anand-94a05613a) |
[Akhil Shrivastava](https://www.linkedin.com/in/akhil-shrivastava-18931814b)

## License ##
This project is licensed under the terms of the MIT license.
