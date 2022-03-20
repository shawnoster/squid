namespace Squid.UserApi.Entities
{
    public record User
    {
        public Guid Id { get; init; }

        public string Name { get; init; } = String.Empty;

        public DateTimeOffset CreatedDate { get; init; }
    }
}