namespace Squid.UserApi.Dtos
{
    public record UserDto
    {
        public Guid Id { get; init; }

        public string Name { get; init; } = String.Empty;

        public DateTimeOffset CreatedDate { get; init; }
    }    
}