using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Org.BouncyCastle.Crypto.Tls;
using System.Security.Cryptography.X509Certificates;

namespace OpenMyGarage.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    //webBuilder.ConfigureKestrel(serverOptions =>
                    //{
                    //    serverOptions.ConfigureHttpsDefaults(listenOptions =>
                    //    {
                    //        listenOptions.ServerCertificate = new X509Certificate2(@"/home/pi/HttpsConfig/https.crt", "password");
                    //    });
                    //});
                });
    }
}
