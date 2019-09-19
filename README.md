<h1 align="center">
  <br>
  <a><img src="https://github.com/Abhishek-Diaspark/The-WeatherMan/blob/master/Backend/WeatherAPIDotNetCore/docs/images/logo.png" alt="DotNet Core"></a>
  <br>
  The WeatherMan Application
  <br>
</h1>

<p align="center">
    <a alt="DotNet Core">
        <img src="https://img.shields.io/badge/DotNet%20Core-v2.2-orange.svg" />
    </a>
    <a alt="Cosmos DB">
        <img src="https://img.shields.io/badge/Cosmos%20DB-latest-brightgreen.svg" />
    </a>    
    <a alt="License">
        <img src="https://img.shields.io/badge/Angular-v6-red.svg" />
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
1. [Application](#Application)
2. [Technology](#Technology)
3. [Projects Link](#Projects-Link)
4. [Run Insider Docker](#Running-the-server-through-Docker-Compose)
5. [Contributors](#Contributors)
6. [License](#License)

## Application ##
The idea of the application is to design a WeatherMan Analysis which shows approximate weather forecast of 5 days ,on the basis of the analysis done on the data from four well known and authorized weather service providers, for the place which user selects and also weatherman checks and compares the last year data of that particular day and thus apply its analysis and predict the forecast.These two are the major factor of the weatherman analysis .The aim of the application is to give the most accurate weather information out of all the service providers.
This application is unique in every aspect whether the idea of its creation or the technologies used to build it. It is very well justified in every phase. The technologies used are the ones which are on the boom in the techno-world right now and thus adds starts to this application.

## Technology ##

##### Angular 6 #####
Angular 6 is a JavaScript framework for building web applications and apps in JavaScript, html, and TypeScript, which is a superset of JavaScript. Angular provides built-in features for animation, http service, and materials which in turn has features such as auto-complete, navigation, toolbar, menus, etc. The code is written in TypeScript, which compiles to JavaScript and displays the same in the browser.

##### Dotnet Core 2.2 #####
ASP.NET Core is a cross-platform, high-performance, open-source framework for building modern, cloud-based, Internet-connected applications. With ASP.NET Core -Build web apps and services, IoT apps, and mobile backends, Deploy to the cloud or on-premises, Use your favorite development tools on Windows, macOS, and Linux.

##### Cosmos DB #####
Azure Cosmos DB is a global distributed, multi-model database that is used in a wide range of applications and use cases. It is a good choice for any serverless application that needs low order-of-millisecond response times, and needs to scale rapidly and globally.

##### Redis #####
Redis can be used to cache data that a web-server needs. Redis gives a structured way to store data in memory. Therefore it is faster than your traditional database that writes to disk. Redis data structures resolve very complex programming problems with simple commands executed within the data store, reducing coding effort, increasing throughput, and reducing latency.

## Projects Link ##
#####  #####
The link for backend which is on DotNet Core v2.2:
[Backend](https://github.com/Abhishek-Diaspark/The-WeatherMan/tree/master/Backend)
#####  #####
The link for frontend which is on Angular is: 
[Frontend](https://github.com/Abhishek-Diaspark/The-WeatherMan/tree/master/Frontend)

## Running the server through Docker Compose ##

##### Create build #####
$ docker-compose build

##### Start the server in daemon thread #####
$ docker-compose up -d

<img src="https://github.com/Abhishek-Diaspark/The-WeatherMan/blob/master/Frontend/docs/images/application-1.png" alt="DotNet Core">

##### Stop the server #####
$ docker-compose down

## Contributors ##
[Abhishek Anand](https://www.linkedin.com/in/abhishek-anand-94a05613a) |
[Akhil Shrivastava](https://www.linkedin.com/in/akhil-shrivastava-18931814b)
## License ##
This project is licensed under the terms of the MIT license.
