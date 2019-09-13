using WeatherAppApi.Models;
using WeatherAppApi.Services;
//using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
//using WeatherAppApi.Controllers;
using Newtonsoft.Json;
//using System.Web.Http;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using StackExchange.Redis;

namespace WeatherAppApi
{

    public class AppConstant
    {
        public static ConnectionMultiplexer rediscon = ConnectionMultiplexer.Connect("weathermanrediscache.redis.cache.windows.net:6380,password=4Oc4jiSiW3SwSwTAQHjBIJ+rYLoFQIxDinM1pNVHl2c=,ssl=True,abortConnect=False");
        public static string COSMOS_CONNECTION_STRING = "CosmosConnectionString";
        public static string COSMOS_DATABASE_NAME = "CosmosDatabaseName";
        public static string REDIS_CONNECTION_STRING = "RedisConnectionString";
        public static string WEATHER_COLLECTION_NAME = "WeatherCollectionName";
        public static string MAPS_API_KEY = "MapsAPIKey";
    }
}