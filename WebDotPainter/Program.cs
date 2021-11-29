using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using WebDotPainter.Database;

namespace WebDotPainter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var context = new AppDbContext())
            {
                TestData.Init(context);
            }

                host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
