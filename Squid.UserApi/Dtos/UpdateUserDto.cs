using System.ComponentModel.DataAnnotations;

namespace Squid.UserApi.Dtos
{
    public record UpdateUserDto
    {
        [Required]
        public string Name { get; init; }
    }
}