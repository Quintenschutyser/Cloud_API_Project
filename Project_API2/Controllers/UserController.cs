using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project_API2.Model;

namespace Project_API2.Controllers
{
    [Route("api/v2/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public LibraryContext _context { get; set; }
        public UserController(LibraryContext ctxt)
        {
            _context = ctxt;
        }

        [HttpGet] //get with sort
        public List<Users> getUsers(string firstName, string lastName, int? id, int page, 
                                            string sortBy, int pageSize = 10, string direction = "asc" )
        {
            IEnumerable<Users> query = _context.Users.ToList();

            if (!string.IsNullOrWhiteSpace(firstName))
                query = query.Where(b => b.firstName == firstName);
            if (!string.IsNullOrWhiteSpace(lastName))
                query = query.Where(b => b.lastName == lastName);
            if (id != null)
                query = query.Where(b => b.Id == id);
            if (string.IsNullOrWhiteSpace(sortBy))
                sortBy = "id";

            switch(sortBy.ToLower())
            {
                case "firstname":
                    if (direction.ToLower() == "asc")
                        query = query.OrderBy(b => b.firstName);
                    else
                        query = query.OrderByDescending(b => b.firstName);
                    break; 
                case "lastname":
                    if (direction.ToLower() == "asc")
                        query = query.OrderBy(b => b.lastName);
                    else
                        query = query.OrderByDescending(b => b.lastName);
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

            query = query.Skip(page * pageSize);
            if (pageSize > 100)
                pageSize = 100;
            query = query.Take(pageSize);

            return query.ToList();
        }

        [Route("{id}")]
        [HttpGet] //get via specifiek id
        public ActionResult<Users> GetUserId(int id)
        {
            var theUser = _context.Users.SingleOrDefault(b => b.Id == id);
            if (theUser == null)
                return NotFound();
            return theUser;
        }
        [Route("filter")]
        [HttpGet] //opvragen met filter
        public List<Users> getUserFilter(string firstName, string lastName)
        {
            IQueryable<Users> query = _context.Users;

            if (!string.IsNullOrWhiteSpace(firstName))
                query = query.Where(b => b.firstName == firstName);
            if (!string.IsNullOrWhiteSpace(lastName))
                query = query.Where(b => b.lastName == lastName);
            return query.ToList();
        }

        [HttpPost] //Een nieuw user toevoegen
        public IActionResult createUser([FromBody] Users newUser)
        {
            _context.Users.Add(newUser);
            _context.SaveChanges();
            return Created("", newUser);
        }

        [Route("{id}")]
        [HttpDelete] // een user verwijderen
        public IActionResult DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
                return NotFound();
            _context.Users.Remove(user);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut] // een land updaten
        public IActionResult UpdateLand([FromBody] Users updateUser)
        {
            _context.Users.Update(updateUser);
            _context.SaveChanges();
            return Ok(updateUser);
        }
    }
}