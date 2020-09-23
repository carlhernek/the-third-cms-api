using System;
using System.Threading.Tasks;

namespace the_third_cms_api.Db
{
    interface IDbSeeder
    {
        //Seed db.
        public abstract Task SeedDb(IServiceProvider serviceProvider);
    }
}
