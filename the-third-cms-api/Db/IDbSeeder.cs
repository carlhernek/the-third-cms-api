using System;

namespace the_third_cms_api.Db
{
    interface IDbSeeder
    {
        //Seed db.
        public abstract void SeedDb(IServiceProvider serviceProvider);
    }
}
