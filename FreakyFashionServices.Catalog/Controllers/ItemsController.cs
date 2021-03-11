using FreakyFashionServices.Catalog.Models.Db;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FreakyFashionServices.Catalog.Controllers
{
    [Route("api/catalog/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly FreakyFashionContext _context;
        public ItemsController(FreakyFashionContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetAllItems()
        {
           var items = _context.Item.ToList();

           return Ok(items);
        }

        [HttpGet("{id}")]
        public ActionResult GetItem(int id)
        {
            var item = _context.Item.Find(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }
    }
}
