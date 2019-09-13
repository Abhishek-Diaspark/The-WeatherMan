namespace WeatherAppApi.Models
{

    public class AverageReport
    {
        public decimal Temp_C { get; set; }
        public decimal Temp_F { get; set; }

        public decimal Humidity { get; set; }

        public decimal Pressure { get; set; }
        public decimal WindSpeed { get; set; }
        public decimal AppearentTemp { get; set; }

    }

}
