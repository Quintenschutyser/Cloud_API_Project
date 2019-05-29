using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Project_API2.Controllers
{
    [Route("api/2")]
    public class FavoriteController : Controller
    {
        [Route("test")]
        public IActionResult Index()
        {
            return Content("Hello");
        }
    }
}