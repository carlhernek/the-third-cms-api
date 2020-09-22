using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using the_third_cms_api.Models;

namespace the_third_cms_api.Db
{
    public class DbSeeder : IDbSeeder
    {
        public void SeedDb(IServiceProvider serviceProvider)
        {


            using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                Random rand = new Random((int)DateTime.Now.Ticks);

                var appDbContext = scope.ServiceProvider.GetService<AppDbContext>();

                appDbContext.Database.Migrate();



                //for (int i = 0; i < rand.Next(5, 200), i++)
                //{

                    



                //}





            }








        }


    }
}
