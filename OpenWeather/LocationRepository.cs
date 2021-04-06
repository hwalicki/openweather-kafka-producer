using OpenWeather.Models;
using System.Collections.Generic;

namespace OpenWeather
{
    public class LocationRepository
    {
        public List<Location> GetAllLocations()
        {
            var response = new List<Location>();
            var filepath = @"filePath\locations.csv"; // Insert real file path

            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(filepath);

            while ((line = file.ReadLine()) != null)
            {
                string[] values = line.Split(',');

                response.Add(
                    new Location
                    {
                        Id = int.Parse(values[0]),
                        CityName = values[1],
                        StateCode = values[2],
                        CountryCode = values[3],
                        CountryName = values[4],
                        Lat = double.Parse(values[5]),
                        Lon = double.Parse(values[6])
                    }
                );
            }

            file.Close();

            return response;
        }
    }
}
