namespace WeatherAppApi.Models
{

    public class AverageApiData
    {
        public decimal precipitation { get; set; }
        public decimal maxTemp { get; set; }

        public string icon { get; set; }

        public string description { get; set; }
        public decimal humid { get; set; }
        public decimal pressure { get; set; }

        public decimal minTemp { get; set; }

        public double wind { get; set; }

    }

}
