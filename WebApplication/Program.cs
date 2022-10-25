using Chilkat;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Models;
using static System.Net.Mime.MediaTypeNames;
using CsvHelper;
using WebApplication.Controllers;
using System.Globalization;

namespace WebApplication1
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            
            //PersonnelController pC = new();

            //var csvPath = Path.Combine(Environment.CurrentDirectory, $"personnel -{DateTime.Now.ToFileTime()}.csv");
            //using (var streamWriter = new StreamWriter(csvPath))
            //{
            //    using CsvWriter csvWriter = new(streamWriter, CultureInfo.InvariantCulture);
            //    var personnel = pC.Get();
            //    csvWriter.WriteRecords(personnel);
            //}
            

           
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}