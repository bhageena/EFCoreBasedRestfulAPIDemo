using EFCoreBasedRestfulAPIDemo.Models;
using EFCoreBasedRestfulAPIDemo.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CreatingARESTfulService.Controllers
{
    [Route("api/[controller]")]
    public class ItemsController : Controller
    {

        ItemsDbContext _context;

        public ItemsController(ItemsDbContext dbContext)
        {
            _context = dbContext;
        }
        [HttpGet]
        public IQueryable<Item> Get()
        {
            return _context.Items.Take(50);
        }

        // GET api/items/5
        [HttpGet("{id}")]
        public Item Get(int id)
        {
            return _context.Items.Find(id);
        }

        // POST api/items
        [HttpPost]
        public void Post([FromBody]Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
        }

        // PUT api/items/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Item value)
        {
            var item = _context.Items.Find(id);
            item.Name = value.Name;
            item.Description = value.Description;
            item.Price = value.Price;
            _context.SaveChanges();
        }

        // DELETE api/items/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _context.Items.Find(id);
            if (item != null)
            {
                _context.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}
