using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using the_third_cms_api.Db;
using the_third_cms_api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace the_third_cms_api.Controllers
{
    [Route("[controller]")]
    public class CmsController : BaseController
    {
        private readonly AppDbContext DbContext;



        public CmsController(AppDbContext dbContext)
        {
            this.DbContext = dbContext;

            for (int i = 0; i < 10; i++)
            {
                this.DbContext.Add(new CmsItem { Id = Guid.NewGuid(), ItemData = "Test", ItemId = i * 1000, Url = "**" });
            }

            DbContext.SaveChanges();
            


        }

        /// <summary>
        /// Get all
        /// </summary>
        /// <returns>List of CmsItems</returns>
        [HttpGet]
        public IEnumerable<CmsItem> Get()
        {
            return DbContext.CmsItems.ToList();
        }

        // GET api/<CmsController>/5
        [HttpGet("{id}")]
        public CmsItem Get(Guid id)
        {
            return DbContext.CmsItems.Where(c => c.Id.Equals(id)).FirstOrDefault();
        }

        // POST api/<CmsController>
        [HttpPost]
        public void Post([FromBody] CmsItem value)
        {
            DbContext.CmsItems.Add(value);
        }


        // PUT api/<CmsController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] CmsItem value)
        {

            var item = DbContext.CmsItems.Where(c => c.Id.Equals(id)).FirstOrDefault();

            DbContext.CmsItems.Update(item);


        }

        // DELETE api/<CmsController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            DbContext.CmsItems.Remove(DbContext.CmsItems.Where(c => c.Id.Equals(id)).FirstOrDefault());
        }
    }
}
