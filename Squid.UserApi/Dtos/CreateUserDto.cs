using System.ComponentModel.DataAnnotations;

namespace Squid.UserApi.Dtos
{
    public record CreateUserDto
    {
        [Required]
        public string Name { get; init; }
    }
}