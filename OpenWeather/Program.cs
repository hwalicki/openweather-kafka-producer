using Confluent.Kafka;
using System.Threading;
using System.Threading.Tasks;

namespace OpenWeather
{
    public class Program
    {
        public static async Task Main()
        {
            var locationRepository = new LocationRepository();
            var locations = locationRepository.GetAllLocations();

            var openWeatherProxy = new OpenWeatherApiProxy();

            var config = new ProducerConfig
            {
                BootstrapServers = "server" // Insert your server
            };

            using (var producer = new ProducerBuilder<Null, string>(config).Build())
            {
                while (true)
                {
                    foreach (var location in locations)
                    {
                        var weather = await openWeatherProxy.GetCurrentWeather(location);
                        producer.Produce("currentWeather", new Message<Null, string> { Value = weather });

                        var pollution = await openWeatherProxy.GetAirPollution(location);
                        producer.Produce("airPollution", new Message<Null, string> { Value = pollution });
                    }

                    // Per API guidelines, only call once per location every 10 minutes
                    // In a real stream or app, it's highly unadvised to do this
                    Thread.Sleep(600000);
                }

                producer.Flush();
            }
        }
    }
}
