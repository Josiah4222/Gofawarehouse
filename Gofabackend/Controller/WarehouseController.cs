using Microsoft.AspNetCore.Mvc;
using Gofabackend.Data; // Assuming your DbContext is here
using Gofabackend.Models; // Assuming your Warehouse entity is here
using Gofabackend.DTO; // Assuming your DTO is here
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using Microsoft.Data.Sqlite;

namespace Gofabackend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class WarehousesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WarehousesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Helper method to map Warehouse entity to WarehouseDto
        private WarehouseDto MapToDto(Warehouse warehouse)
        {
            return new WarehouseDto
            {
                WarehouseId = warehouse.WarehouseId,
                Name = warehouse.Name,
                Location = warehouse.Location
            };
        }

        // GET: api/warehouses
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<WarehouseDto>>> GetWarehouses()
        {
            var warehouses = await _context.Warehouses.ToListAsync();
            return warehouses.Select(MapToDto).ToList(); // Manually map each entity to DTO
        }

        // GET: api/warehouses/{id}
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<WarehouseDto>> GetWarehouse(string id)
        {
            var warehouse = await _context.Warehouses.FindAsync(id);

            if (warehouse == null)
            {
                return NotFound();
            }

            return MapToDto(warehouse); // Manually map the entity to DTO
        }

        // POST: api/warehouses
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<WarehouseDto>> CreateWarehouse([FromBody] WarehouseDto warehouseDto)
        {
            if (warehouseDto == null)
            {
                return BadRequest("Invalid warehouse data.");
            }

            var warehouse = new Warehouse
            {
                WarehouseId = warehouseDto.WarehouseId,
                Name = warehouseDto.Name,
                Location = warehouseDto.Location
            };

            try
            {
                _context.Warehouses.Add(warehouse);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is SqliteException sqliteEx && sqliteEx.SqliteErrorCode == 19)
                {
                    return Conflict("A warehouse with the same ID already exists.");
                }
                return StatusCode(500, "An error occurred while saving the warehouse.");
            }

            return CreatedAtAction(nameof(GetWarehouse), new { id = warehouse.WarehouseId }, MapToDto(warehouse));
        }

        // PUT: api/warehouses/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWarehouse(string id, [FromBody] WarehouseDto updatedWarehouseDto)
        {
            if (id != updatedWarehouseDto.WarehouseId)
            {
                return BadRequest("Mismatch between ID in URL and warehouse ID.");
            }

            var existingWarehouse = await _context.Warehouses.FindAsync(id);

            if (existingWarehouse == null)
            {
                return NotFound();
            }

            existingWarehouse.Name = updatedWarehouseDto.Name;
            existingWarehouse.Location = updatedWarehouseDto.Location;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/warehouses/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWarehouse(string id)
        {
            var warehouse = await _context.Warehouses.FindAsync(id);

            if (warehouse == null)
            {
                return NotFound();
            }

            _context.Warehouses.Remove(warehouse);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}