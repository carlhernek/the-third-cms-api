using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using the_third_cms_api.Db;

namespace the_third_cms_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            //var scope = host.Services.CreateScope();
            ////Try seed db.
            //try
            //{
            //    var dbSeeder = (DbSeeder)scope.ServiceProvider.GetRequiredService<IDbSeeder>();

            //    dbSeeder.SeedDb(scope.ServiceProvider);

            //}
            //catch (Exception e)
            //{
            //    throw e;
            //}

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
