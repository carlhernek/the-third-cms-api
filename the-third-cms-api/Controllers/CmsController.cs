using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using the_third_cms_api.Db;
using the_third_cms_api.Models;
using the_third_cms_api.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace the_third_cms_api.Controllers
{

    [Route("api/[controller]")]
    public class CmsController : BaseController
    {
        private readonly AppDbContext DbContext;

        private readonly ILogger<CmsController> Logger;
        private readonly IFileService FileService;

        public CmsController(AppDbContext dbContext, ILogger<CmsController> logger, IFileService fileService)
        {
            this.DbContext = dbContext;

            this.Logger = logger;
            this.FileService = fileService;

        }



        /// <summary>
        /// Get All Async
        /// </summary>
        /// <returns>List of CmsItems</returns>
        [HttpGet]
        public async Task<IEnumerable<CmsItem>> GetAsync()
        {
            Logger.LogInformation("Getting all items.");
            var items = await this.DbContext.CmsItems.ToListAsync();

            return items;
        }

        /// <summary>
        /// GetById
        /// </summary>
        /// <returns>List of CmsItems</returns>
        [HttpGet("{id}")]
        public async Task<CmsItem?> GetItemByIdAsync(Guid id)
        {
            Logger.LogInformation($"Getting item by id: {id}.");
            var item = await this.DbContext.CmsItems.Where(c => c.Id.Equals(id)).FirstOrDefaultAsync();

            if (item is null)
            {
                // TODO: Do something sensible.
                //Error!
                Logger.LogError($"Item with {id} does not exist!");
            }
            Logger.LogInformation($"Item with {id} found.");
            return item;

        }



        /// <summary>
        /// GetItemsByUrlAsync
        /// </summary>
        /// <param name="url">Url for associated items.</param>
        /// <returns>Returns all Items for the provided Url.</returns>
        [HttpGet("{url}")]
        // GET api/<CmsController>/5
        public async Task<IEnumerable<CmsItem>> GetItemsByUrlAsync(string url)
        {
            // We use Nullable notation, we don't need null checks here!
            //if (url is null)
            //{
            //    // TODO: Handle this better.
            //    Logger.LogError($"Url is null!, redirecting to get.");
            //    RedirectToAction(nameof(GetAsync));
            //}
            Logger.LogInformation($"Getting Items with url: {url}.");

            var res = await DbContext.CmsItems.Where(c => c.Url.ToLowerInvariant().Equals(url.ToLowerInvariant())).ToListAsync();
            Logger.LogInformation($"Found {url.Length} items on url: {url}.");
            return res;
        }



        /// <summary>
        /// Creates a new Item
        /// </summary>
        /// <param name="value">CmsItemViewModel</param>
        /// <returns>returns int depending on success.</returns>
        [HttpPost]
        public async Task<int> PostAsync([FromBody] CmsItemVm value)
        {
            //We use Nullable notation, we no longer need to nullcheck, i think!
            //if (value is null)
            //{
            //    Logger.LogError($"Trying to create a new item with no data! Redirection to base {} ");
            //}
            //var json = JsonSerializer.Deserialize(value, typeof(CmsItem));
            var cmsitem = new CmsItem
            {
                ItemData = value.ItemData,
                ItemId = value.ItemId,
                ItemType = value.ItemType
            };
            await DbContext.CmsItems.AddAsync(cmsitem);
            return await DbContext.SaveChangesAsync();
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        // PUT api/<CmsController>/5
        [HttpPut("{id}")]
        public int Put(Guid? id, [FromBody] CmsItemVm value)
        {
            if (id is null)
            {
                //Trying to put without ID, will redirect to post.
                RedirectToAction(nameof(PostAsync), value);
            }
            var item = DbContext.CmsItems.Where(c => c.Id.Equals(id)).FirstOrDefault();

            item = new CmsItem
            {
                ItemId = value.ItemId,
                ItemData = value.ItemData,
                ItemType = value.ItemType,
                Url = value.Url
            };


            DbContext.CmsItems.Update(item);
            return DbContext.SaveChanges();


        }

        // DELETE api/<CmsController>/5
        [HttpDelete("{id}")]
        public int Delete(Guid id)
        {
            DbContext.CmsItems.Remove(DbContext.CmsItems.Where(c => c.Id.Equals(id)).FirstOrDefault());
            return DbContext.SaveChanges();
        }
    }
}
