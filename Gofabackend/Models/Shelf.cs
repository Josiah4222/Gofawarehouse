using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Gofabackend.Models;

public class Shelf
{
    [Key]
    [StringLength(36)]
    public string ShelfId { get; set; } = Guid.NewGuid().ToString();
    
    public string Name { get; set; }
    public string Column { get; set; }
    public string Row { get; set; }
    
    [NotMapped]
    public string WarehouseName { get; set; }

    [StringLength(36)]
    public string WarehouseId { get; set; }
    
    [ForeignKey("WarehouseId")]
    public Warehouse Warehouse { get; set; }
}