using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using the_third_cms_api.Models;

namespace the_third_cms_api.Db
{
    public class DbSeeder : IDbSeeder
    {

        private string[] words = { };
        private string[] urls =
        {
            "http://localhost:5000/",
            "http://localhost:5000/counter",
            "http://localhost:5000/fetch",
            "https://localhost:5001/",
            "https://localhost:5001/counter",
            "https://localhost:5001/fetch",
        };
        public async Task SeedDb(IServiceProvider serviceProvider)
        {
            this.words = await ReadWordsFromFile();


            using var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();


            var appDbContext = scope.ServiceProvider.GetService<AppDbContext>();

            appDbContext.Database.Migrate();

            await AddMockData(appDbContext);

        }

        private async Task<int> AddMockData(AppDbContext dbContext)
        {

            if (!dbContext.CmsItems.Any())
            {
                Random rand = new Random((int)DateTime.Now.Ticks);


                List<CmsItem> items = new List<CmsItem>();
                for (int i = 0; i < 10; i++)
                {

                    var cms = new CmsItem
                    {
                        //2 000 000 items would be max in db for EACH Url.
                        ItemId = rand.Next(0, 2000000),
                        ItemData = words[rand.Next(0, words.Length)],
                        Image = null,
                        Url = urls[rand.Next(0, urls.Length)]
                    };

                    //if (items.Any())
                    //{
                    //    foreach (var cmsItem in DbCOnt)
                    //    {
                    //        //Compare ItemId, int is faster than string.
                    //        if (cms.ItemId == cmsItem.ItemId)
                    //        {
                    //            //Check url
                    //            if (cms.Url.Equals(cmsItem.Url))
                    //            {
                    //                while (cms.ItemId == cmsItem.ItemId)
                    //                    cms.ItemId = rand.Next(0, 2000000);
                    //            }
                    //        }

                    //    }
                    //}
                    //items.Add(cms);
                    if (dbContext.CmsItems.Any())
                    {
                        foreach (var cmsItem in dbContext.CmsItems.ToList())
                        {
                            //Compare ItemId, int is faster than string.
                            if (cms.ItemId == cmsItem.ItemId)
                            {
                                //Check url
                                if (cms.Url.Equals(cmsItem.Url))
                                {
                                    while (cms.ItemId == cmsItem.ItemId)
                                        cms.ItemId = rand.Next(0, 2000000);
                                }
                            }

                        }
                    }
                    await dbContext.CmsItems.AddAsync(cms);
                    dbContext.SaveChanges();
                }




            }

            return -1;


        }


        private async Task<string[]> ReadWordsFromFile()
        {

            string[] err = { "Error", "No", "word.txt", "file" };
            try
            {
                if (!File.Exists("words.txt"))
                    return err;

                string[] strArr = await File.ReadAllLinesAsync("words.txt", Encoding.UTF8);

                if (strArr is null)
                    return err;
                return strArr;
            }
            catch (Exception e)
            {
                throw e;
            }


        }


    }
}
