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

        [HttpGet] //opvragen van gegevens
        public List<Land> GetLands(string name, string Alpha3Code,int? id, string Currency, int Page, string sortBy, 
                                            int PageSize = 10, string direction = "asc")
        {
            IEnumerable<Land> query = _context.Land.ToList();

            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(b => b.Name == name);
            if (!string.IsNullOrWhiteSpace(Alpha3Code))
                query = query.Where(b => b.Alpha3Code == Alpha3Code);
            if (!string.IsNullOrWhiteSpace(Currency))
                query = query.Where(b => b.Currency == Currency);
            if (id != null)
                query = query.Where(b => b.Id == id);
            if (string.IsNullOrWhiteSpace(sortBy))
                sortBy = "name";

            switch (sortBy.ToLower())
            {
                case "name":
                    if (direction.ToLower() == "asc")
                        query = query.OrderBy(b => b.Name);
                    else
                        query = query.OrderByDescending(b => b.Name);
                    break;
                case "alpha3code":
                    if (direction.ToLower() == "asc")
                        query = query.OrderBy(b => b.Alpha3Code);
                    else
                        query = query.OrderByDescending(b => b.Alpha3Code);
                    break;
                case "Currency":
                    if (direction.ToLower() == "asc")
                        query = query.OrderBy(b => b.Currency);
                    else
                        query = query.OrderByDescending(b => b.Currency);
                    break;
                case "id":
                    if (direction.ToLower() == "asc")
                        query = query.OrderBy(b => b.Id);
                    else
                        query = query.OrderByDescending(b => b.Id);
                    break;
                default:
                    break;
            }

            query = query.Skip(Page * PageSize);
            if (PageSize > 100)
                PageSize = 100;
            query = query.Take(PageSize);

            return query.ToList();
        }

        [Route("filter")]
        [HttpGet] //opvragen met filter
        public List<Land> GetFilterLand(string currency)
        {
            IQueryable<Land> query = _context.Land;

            if (!string.IsNullOrWhiteSpace(currency))
                query = query.Where(b => b.Currency == currency);
            return query.ToList();
        }

        [Route("{id}")]
        [HttpGet] //Opvragen via ID
        public ActionResult<Land> getLand(int id)
        {
            var theland = _context.Land.SingleOrDefault(b => b.Id == id);
            if (theland == null)
                return NotFound();
            return theland;

        }

        [HttpPost] //Een nieuw land toevoegen
        public IActionResult createLand([FromBody] Land newLand)
        {
            _context.Land.Add(newLand);
            _context.SaveChanges();
            return Created("", newLand);
        }

        [Route("{id}")]
        [HttpDelete] // een land verwijderen
        public IActionResult DeleteLand(int id)
        {
            var land = _context.Land.Find(id);
            if (land == null)
                return NotFound();
            _context.Land.Remove(land);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut] // een ladn updaten
        public IActionResult UpdateLand([FromBody] Land updateLand)
        {
            _context.Land.Update(updateLand);
            _context.SaveChanges();
            return Ok(updateLand);
        }

        [Route("test")] //test
        [HttpGet]
        public IActionResult Index()
        {
            var result = Content("hello");
            result.StatusCode = 200;
            return result;
        }

        [Route("landtest")] //test
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