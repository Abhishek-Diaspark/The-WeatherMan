
namespace WeatherAppApi
{
    public class DescriptionCalculator
    {

        public string ProvideDescription(string description)
        {

            switch (description)
            {
                case "Thunderstorm":
                    return "Rain & Thunder";
                case "Drizzle":
                    return "Rainy";
                case "Rain":
                    return "Rainy";
                case "Snow":
                    return "Snowy";
                case "Clear":
                    return "Sunny";
                case "Clouds":
                    return "Cloudy";
                case "Mist":
                    return "Rainy";
                case "Haze":
                    return "Rainy";
                case "Fog":
                    return "Rainy";
                default:
                    return "Sunny";
            }
        }
    }

}
