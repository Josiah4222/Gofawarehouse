namespace Gofabackend.DTO
{
    public class UpdateRolesDto
    {
        public string UserId { get; set; }
        public IList<string> Roles { get; set; }
    }
}