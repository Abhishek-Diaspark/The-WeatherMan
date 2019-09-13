using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using WeatherAppApi;
using WeatherAppApi.Models;

namespace WeatherCore.BO
{
    public class AverageDataAggrigator
    {
        private readonly GetWeatherApiData _getweatherapidata;
        private JObject _resultJaobject;
        public AverageDataAggrigator(GetWeatherApiData getweatherapidata)
        {
            _getweatherapidata = getweatherapidata;
        }

        public JObject GetAverageAggrigatedData(string lat, string longi)
        {
            var openweather = _getweatherapidata.getOpenWeatherApiData(lat, longi);
            JObject json1 = JObject.Parse(openweather);
            var darksky = _getweatherapidata.getDarkSkyApiData(lat, longi);
            JObject json2 = JObject.Parse(darksky);
            var weatherunlock = _getweatherapidata.getWeatherUnlockApiData(lat, longi);
            JObject json3 = JObject.Parse(weatherunlock);

            AverageApiData obj = new AverageApiData();
            _resultJaobject = new JObject();
            var dataopen0 = json1["list"][0]["main"];
            var dataopen1 = json1["list"][1]["main"];
            var dataopen2 = json1["list"][2]["main"];
            var dataopen3 = json1["list"][3]["main"];
            var dataopen4 = json1["list"][4]["main"];

            var dataopen00 = json1["list"][0]["wind"];
            var dataopen11 = json1["list"][1]["wind"];
            var dataopen22 = json1["list"][2]["wind"];
            var dataopen33 = json1["list"][3]["wind"];
            var dataopen44 = json1["list"][4]["wind"];

            var desc = json1["list"][0]["weather"][0]["main"].ToObject<string>();
            DescriptionCalculator descCal = new DescriptionCalculator();
            string finalDesc = descCal.ProvideDescription(desc);

            obj.precipitation = (json2["daily"]["data"][0]["precipIntensityMax"].ToObject<Decimal>() + json3["Days"][0]["prob_precip_pct"].ToObject<Decimal>()) / 2;
            obj.maxTemp = ((dataopen0["temp_max"].ToObject<Decimal>() - 273) + ((5 * (json2["daily"]["data"][0]["temperatureHigh"].ToObject<Decimal>() - 32)) / 9) + json3["Days"][0]["temp_max_c"].ToObject<Decimal>()) / 3;
            obj.icon = json3["Days"][0]["Timeframes"][0]["wx_icon"].ToObject<String>();
            Console.WriteLine(obj.icon);
            //obj.description=json2["daily"]["data"][0]["summary"].ToObject<String>();
            obj.description = finalDesc;
            obj.humid = (dataopen0["humidity"].ToObject<Decimal>() + (json2["daily"]["data"][0]["humidity"].ToObject<Decimal>() * 100) + json3["Days"][0]["humid_max_pct"].ToObject<Decimal>()) / 3;
            obj.pressure = (dataopen0["pressure"].ToObject<Decimal>() + json2["daily"]["data"][0]["pressure"].ToObject<Decimal>()) / 2;
            obj.minTemp = ((dataopen0["temp_min"].ToObject<Decimal>() - 273) + ((5 * (json2["daily"]["data"][0]["temperatureLow"].ToObject<Decimal>() - 32)) / 9) + json3["Days"][0]["temp_min_c"].ToObject<Decimal>()) / 3;
            obj.wind = (json2["daily"]["data"][0]["windSpeed"].ToObject<Double>() + dataopen00["speed"].ToObject<Double>() * 3.6 + json3["Days"][0]["windspd_max_mph"].ToObject<Double>()) / 3;
            _resultJaobject.Add("0", JObject.FromObject(obj));

            json1["list"][1]["weather"][0]["main"].ToObject<string>();
            finalDesc = descCal.ProvideDescription(desc);
            obj.precipitation = json2["daily"]["data"][1]["precipIntensityMax"].ToObject<Decimal>() + json3["Days"][1]["prob_precip_pct"].ToObject<Decimal>() / 2;
            obj.maxTemp = ((dataopen1["temp_max"].ToObject<Decimal>() - 273) + ((5 * (json2["daily"]["data"][1]["temperatureHigh"].ToObject<Decimal>() - 32)) / 9) + json3["Days"][1]["temp_max_c"].ToObject<Decimal>()) / 3;
            obj.icon = json3["Days"][1]["Timeframes"][0]["wx_icon"].ToObject<String>();
            // obj.description=json2["daily"]["data"][1]["summary"].ToObject<String>();
            Console.WriteLine(obj.icon);
            obj.description = finalDesc;
            obj.humid = (dataopen1["humidity"].ToObject<Decimal>() + (json2["daily"]["data"][1]["humidity"].ToObject<Decimal>() * 100) + json3["Days"][1]["humid_max_pct"].ToObject<Decimal>()) / 3; ;
            obj.pressure = (dataopen1["pressure"].ToObject<Decimal>() + json2["daily"]["data"][1]["pressure"].ToObject<Decimal>()) / 2;
            obj.minTemp = ((dataopen1["temp_min"].ToObject<Decimal>() - 273) + ((5 * (json2["daily"]["data"][1]["temperatureLow"].ToObject<Decimal>() - 32)) / 9) + json3["Days"][1]["temp_min_c"].ToObject<Decimal>()) / 3;
            obj.wind = (json2["daily"]["data"][1]["windSpeed"].ToObject<Double>() + (dataopen11["speed"].ToObject<Double>() * 3.6) + json3["Days"][1]["windspd_max_mph"].ToObject<Double>()) / 3;
            _resultJaobject.Add("1", JObject.FromObject(obj));

            json1["list"][2]["weather"][0]["main"].ToObject<string>();
            finalDesc = descCal.ProvideDescription(desc);
            obj.precipitation = json2["daily"]["data"][2]["precipIntensityMax"].ToObject<Decimal>() + json3["Days"][2]["prob_precip_pct"].ToObject<Decimal>() / 2;
            obj.maxTemp = ((dataopen2["temp_max"].ToObject<Decimal>() - 273) + ((5 * (json2["daily"]["data"][2]["temperatureHigh"].ToObject<Decimal>() - 32)) / 9) + json3["Days"][2]["temp_max_c"].ToObject<Decimal>()) / 3;
            obj.icon = json3["Days"][2]["Timeframes"][0]["wx_icon"].ToObject<String>();
            //obj.description=json2["daily"]["data"][2]["summary"].ToObject<String>();
            Console.WriteLine(obj.icon);
            obj.description = finalDesc;
            obj.humid = (dataopen2["humidity"].ToObject<Decimal>() + (json2["daily"]["data"][2]["humidity"].ToObject<Decimal>() * 100) + json3["Days"][2]["humid_max_pct"].ToObject<Decimal>()) / 3;
            obj.pressure = (dataopen2["pressure"].ToObject<Decimal>() + json2["daily"]["data"][2]["pressure"].ToObject<Decimal>()) / 2;
            obj.minTemp = ((dataopen2["temp_min"].ToObject<Decimal>() - 273) + ((5 * (json2["daily"]["data"][2]["temperatureLow"].ToObject<Decimal>() - 32)) / 9) + json3["Days"][2]["temp_min_c"].ToObject<Decimal>()) / 3;
            obj.wind = (json2["daily"]["data"][2]["windSpeed"].ToObject<Double>() + dataopen22["speed"].ToObject<Double>() * 3.6 + json3["Days"][2]["windspd_max_mph"].ToObject<Double>()) / 3;
            _resultJaobject.Add("2", JObject.FromObject(obj));

            json1["list"][3]["weather"][0]["main"].ToObject<string>();
            finalDesc = descCal.ProvideDescription(desc);

            obj.precipitation = json2["daily"]["data"][3]["precipIntensityMax"].ToObject<Decimal>() + json3["Days"][3]["prob_precip_pct"].ToObject<Decimal>() / 2;
            obj.maxTemp = ((dataopen3["temp_max"].ToObject<Decimal>() - 273) + ((5 * (json2["daily"]["data"][3]["temperatureHigh"].ToObject<Decimal>() - 32)) / 9) + json3["Days"][3]["temp_max_c"].ToObject<Decimal>()) / 3;
            obj.icon = json3["Days"][3]["Timeframes"][0]["wx_icon"].ToObject<String>();
            //obj.description=json2["daily"]["data"][3]["summary"].ToObject<String>();
            Console.WriteLine(obj.icon);
            obj.description = finalDesc;
            obj.humid = (dataopen3["humidity"].ToObject<Decimal>() + (json2["daily"]["data"][3]["humidity"].ToObject<Decimal>() * 100) + json3["Days"][3]["humid_max_pct"].ToObject<Decimal>()) / 3;
            obj.pressure = (dataopen3["pressure"].ToObject<Decimal>() + json2["daily"]["data"][3]["pressure"].ToObject<Decimal>()) / 2;
            obj.minTemp = ((dataopen3["temp_min"].ToObject<Decimal>() - 273) + ((5 * (json2["daily"]["data"][3]["temperatureLow"].ToObject<Decimal>() - 32)) / 9) + json3["Days"][3]["temp_min_c"].ToObject<Decimal>()) / 3;
            obj.wind = (json2["daily"]["data"][3]["windSpeed"].ToObject<Double>() + dataopen33["speed"].ToObject<Double>() * 3.6 + json3["Days"][3]["windspd_max_mph"].ToObject<Double>()) / 3;
            _resultJaobject.Add("3", JObject.FromObject(obj));

            json1["list"][4]["weather"][0]["main"].ToObject<string>();
            finalDesc = descCal.ProvideDescription(desc);
            obj.precipitation = json2["daily"]["data"][4]["precipIntensityMax"].ToObject<Decimal>() + json3["Days"][4]["prob_precip_pct"].ToObject<Decimal>() / 2;
            obj.maxTemp = ((dataopen4["temp_max"].ToObject<Decimal>() - 273) + ((5 * (json2["daily"]["data"][4]["temperatureHigh"].ToObject<Decimal>() - 32)) / 9) + json3["Days"][4]["temp_max_c"].ToObject<Decimal>()) / 3;
            obj.icon = json3["Days"][4]["Timeframes"][0]["wx_icon"].ToObject<String>();
            //obj.description=json2["daily"]["data"][4]["summary"].ToObject<String>();
            Console.WriteLine(obj.icon);
            obj.description = finalDesc;
            obj.humid = (dataopen4["humidity"].ToObject<Decimal>() + (json2["daily"]["data"][4]["humidity"].ToObject<Decimal>() * 100) + json3["Days"][4]["humid_max_pct"].ToObject<Decimal>()) / 3;
            obj.pressure = (dataopen4["pressure"].ToObject<Decimal>() + json2["daily"]["data"][4]["pressure"].ToObject<Decimal>()) / 2;
            obj.minTemp = ((dataopen4["temp_min"].ToObject<Decimal>() - 273) + ((5 * (json2["daily"]["data"][4]["temperatureLow"].ToObject<Decimal>() - 32)) / 9) + json3["Days"][4]["temp_min_c"].ToObject<Decimal>()) / 3;
            obj.wind = (json2["daily"]["data"][3]["windSpeed"].ToObject<Double>() + dataopen33["speed"].ToObject<Double>() * 3.6 + json3["Days"][3]["windspd_max_mph"].ToObject<Double>()) / 3;
            _resultJaobject.Add("4", JObject.FromObject(obj));

            return _resultJaobject;
        }

    }
}
