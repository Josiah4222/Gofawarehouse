namespace Gofabackend.DTO
{
    public class UserRoleViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}