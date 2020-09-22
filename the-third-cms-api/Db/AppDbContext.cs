using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using the_third_cms_api.Models;

namespace the_third_cms_api.Db
{
    public class AppDbContext : DbContext
    {
#nullable disable
        public DbSet<CmsItem> CmsItems { get; set; }

#nullable enable

        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Update all models 
            foreach (var entity in builder.Model.GetEntityTypes().Where(entityType => typeof(IBaseModel).IsAssignableFrom(entityType.ClrType)))
            {
                builder.Entity(entity.ClrType).Property<DateTime>("CreatedAt");
                builder.Entity(entity.ClrType).Property<DateTime>("ModifiedAt");
            }
            builder.Ignore<BaseModel>();
            builder.Ignore<IBaseModel>();

            //builder.Entity<CmsItem>().ToTable("CmsItems").HasKey(ct => ct.Id);

            //builder.Entity<CmsItem>().HasDiscriminator<ItemType>().HasValue(ItemType.Image).HasValue(ItemType.Text);


        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<CmsItem>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = entry.Entity.ModifiedAt = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedAt = DateTime.Now;
                        break;
                    default:
                        break;

                }
            }

            return base.SaveChangesAsync(cancellationToken);


        }

    }
}
