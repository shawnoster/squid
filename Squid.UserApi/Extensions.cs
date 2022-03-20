using Squid.UserApi.Dtos;
using Squid.UserApi.Entities;

namespace Squid.UserApi
{
    public static class Extensions
    {
        public static UserDto AsDto(this User user)
        {
            return new UserDto{
                Id = user.Id,
                Name = user.Name,
                CreatedDate = user.CreatedDate
            };
        }
    }
}