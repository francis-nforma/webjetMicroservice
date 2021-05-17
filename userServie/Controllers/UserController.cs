using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using userService.Database;
using userService.Database.Entities;
using userService.Database.Repository;

namespace UserService.Controllers
{

    //private readonly IDataRepository<Car, CarDTO> _dataRepository;

    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IDataRepository<User> _dataRepository;

        /// </summary>
        public UserController(IDataRepository<User> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        //GET api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            var users = await _dataRepository.GetAll();
            return Ok(users);
        }

        // GET api/users/1
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetAsync(int id)
        {
            var user = await _dataRepository.Get(id);
            if (user == null)
            {
                return NotFound("User not found.");
            }
            return Ok(user);
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] User user)
        {
            var newUser = await _dataRepository.Add(user);
            return CreatedAtAction(nameof(Get), new { id = newUser.Id }, newUser);
        }

        private async Task<ActionResult<User>> Get(int id)
        {
            var user = await _dataRepository.Get(id);
            if (user == null)
            {
                return NotFound("User not found.");
            }
            return Ok(user);
        }

        // PUT api/values/1
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }
            await _dataRepository.Update(user);
            return NoContent();
        }

        // DELETE api/values/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var useroDelete = await _dataRepository.Get(id);
            if (useroDelete == null)
            {
                return NotFound();
            }
            await _dataRepository.Delete(useroDelete.Id);
            return NoContent();
        }
    }
}
