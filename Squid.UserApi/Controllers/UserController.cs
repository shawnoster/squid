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
    }
}