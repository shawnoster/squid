using Microsoft.AspNetCore.Mvc;
using Squid.UserApi.Dtos;
using Squid.UserApi.Repositories;

namespace Squid.UserApi.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository repository;

        public UserController(IUserRepository repository)
        {
            this.repository = repository;
        }

        // GET /users
        [HttpGet]
        public IEnumerable<UserDto> GetUsers()
        {
            var users = repository.GetUsers().Select( user => user.AsDto());

            return users;
        }

        // GET /users/{id}
        [HttpGet("id")]
        public ActionResult<UserDto> GetUser(Guid id)
        {
            var user = repository.GetUser(id);

            if (user is null)
            {
                return NotFound();
            }

            return user.AsDto();
        }

        // POST /users
        [HttpPost]
        public ActionResult<UserDto> CreateUser(CreateUserDto userDto)
        {
            Entities.User user = new()
            {
                Id = Guid.NewGuid(),
                Name = userDto.Name,
                CreatedDate = DateTimeOffset.UtcNow
            };

            repository.CreateUser(user);

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user.AsDto());
        }

        // PUT /users/{id}
        [HttpPut("id")]
        public ActionResult UpdateUser(Guid id, UpdateUserDto userDto)
        {
            var existingUser = repository.GetUser(id);

            if (existingUser is null)
            {
                return NotFound();
            }

            Entities.User updatedUser = existingUser with 
            {
                Name = userDto.Name
            };

            repository.UpdateUser(updatedUser);

            return NoContent();
        }

        // DEL /users/{id}
        [HttpDelete("id")]
        public ActionResult DeleteUser(Guid id)
        {
            var existingUser = repository.GetUser(id);

            if (existingUser is null)
            {
                return NotFound();
            }
                        
            repository.DeleteUser(id);

            return NoContent();
        }
    }
}