namespace OpenWeather.Models
{
    public class Location
    {
        public int Id { get; set; }

        public string CityName { get; set; }

        public string StateCode { get; set; }

        public string CountryCode { get; set; }

        public string CountryName { get; set; }

        public double Lat { get; set; }

        public double Lon { get; set; }
    }
}
