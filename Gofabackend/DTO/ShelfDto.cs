using System.ComponentModel.DataAnnotations;
namespace Gofabackend.DTO{
    public class ShelfDto
    {
        [Required]
        public string Name { get; set; }
        public string Column { get; set; }
        public string Row { get; set; }
        [Required]
        public string WarehouseName { get; set; }
    }
}
