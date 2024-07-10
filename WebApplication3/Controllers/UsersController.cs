using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase

    {
        private static List<User> users = new List<User>();

        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return users;
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            var user = users.FirstOrDefault(x => x.Id == id);
            return user;
        }

        // POST api/<UsersController>
        [HttpPost]
        [ProducesResponseType(typeof(User), 201)]
        [ProducesResponseType(typeof(Error), 400)]

        public void Post([FromBody] UserRequest request)
        {

            if (string.IsNullOrEmpty(request.Name))
            {
                Error error = new Error();
                error Message = "The Name field is required."

               BadRequest(error);

            }
            User user = new User();
            user.Email = request.Email;
            user.Name = request.Name;
            user.Job =  request .Job;
            user.Id = users.Count() + 1 ;
    
            users.Add(user);
            CreatedAtAction("Get",new {id = user.Id}, user);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User request)
        {
            var user = users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                // user.Id = id;
                user.Name = request.Name;
                user.Email = request.Email;
                user.Job = request.Job;
                return Ok(user);
            }
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
             void Delete(int id)
        {
                var user = users.FirstOrDefault(x => x.Id == id);
                users.Remove(user);
        }
    }
}
