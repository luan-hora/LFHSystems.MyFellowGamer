using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace LFHSystems.MyFellowGamer.ConsoleApp
{
    class Program
    {
        static IConfigurationRoot config;

        static void Main(string[] args)
        {
            InitializeConfiguration();

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }

        private static void InitializeConfiguration()
        {
            string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            string path = Directory.GetCurrentDirectory();
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appSettings.json", true, true)
                .AddJsonFile($"appSettings.{env}.json", true, true)
                .AddEnvironmentVariables();

            config = builder.Build();

            var cfg = config.Get<AppConfig>();
        }
    }

    #region Classes mapping configuração
    public class AppConfig
    {
        public string ConnectionString { get; set; }
    }
    #endregion


}
