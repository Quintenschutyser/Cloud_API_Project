using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project_API2.Model;

namespace Project_API2.Controllers
{
    [Route("api/v2/")]
    [ApiController]
    public class FavoriteController : Controller
    {
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
        public List<Land> getLand()
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