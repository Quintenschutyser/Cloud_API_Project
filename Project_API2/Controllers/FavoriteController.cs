using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_API2.Model;

namespace Project_API2.Controllers
{
    [Route("api/v2/land")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        public LibraryContext _context { get; set; }
        public FavoriteController(LibraryContext ctxt)
        {
            _context = ctxt;
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult<Land> getLand(int id)
        {
            var theland = _context.Land.SingleOrDefault(b => b.Id == id);
            if (theland == null)
                return NotFound();
            return theland;

        }

        [HttpPost]
        public ActionResult<Land> AddBook([FromBody]Land land)
        {
            _context.Land.Add(land);
            _context.SaveChanges();
            //return boek met ID
            return Created("", land);
        }



        [Route("test")]
        [HttpGet]
        public IActionResult Index()
        {
            var result = Content("hello");
            result.StatusCode = 200;
            return result;
        }

        [Route("landtest")]
        [HttpGet]
        public List<Land> getLandTest()
        {
            var l1 = new List<Land>();
            l1.Add(new Land()
            {
                Name = "Belgium",
                Currency = "EUR"
            });
            l1.Add(new Land()
            {
                Name = "France",
                Currency = "EUR"
            });
            l1.Add(new Land()
            {
                Name = "United state of America",
                Currency = "USD"
            });
            return l1;
        }
    }
}