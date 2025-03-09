using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gofabackend.Models;
using System.ComponentModel.DataAnnotations;
using Gofabackend.Data;
using Gofabackend.DTO;

namespace Gofabackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShelfController : ControllerBase
    {
        private readonly ApplicationDbContext _context; // Replace with your actual DbContext name

        public ShelfController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Shelf
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shelf>>> GetShelves()
        {
            return await _context.Shelves
                .Include(s => s.Warehouse)
                .ToListAsync();
        }

        // GET: api/Shelf/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shelf>> GetShelf(string id)
        {
            var shelf = await _context.Shelves
                .Include(s => s.Warehouse)
                .FirstOrDefaultAsync(s => s.ShelfId == id);

            if (shelf == null)
            {
                return NotFound();
            }

            return shelf;
        }

        // POST: api/Shelf
        [HttpPost]
        public async Task<ActionResult<Shelf>> CreateShelf(ShelfDto shelfDto)
        {
            // Find warehouse by name
            var warehouse = await _context.Warehouses
                .FirstOrDefaultAsync(w => w.Name == shelfDto.WarehouseName);

            if (warehouse == null)
            {
                return BadRequest("Warehouse not found");
            }

            var shelf = new Shelf
            {
                Name = shelfDto.Name,
                Column = shelfDto.Column,
                Row = shelfDto.Row,
                WarehouseId = warehouse.WarehouseId,
                WarehouseName = warehouse.Name
            };

            _context.Shelves.Add(shelf);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetShelf), new { id = shelf.ShelfId }, shelf);
        }

        // PUT: api/Shelf/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShelf(string id, ShelfDto shelfDto)
        {
            var shelf = await _context.Shelves.FindAsync(id);
            if (shelf == null)
            {
                return NotFound();
            }

            // Find warehouse by name if provided
            if (!string.IsNullOrEmpty(shelfDto.WarehouseName))
            {
                var warehouse = await _context.Warehouses
                    .FirstOrDefaultAsync(w => w.Name == shelfDto.WarehouseName);

                if (warehouse == null)
                {
                    return BadRequest("Warehouse not found");
                }
                shelf.WarehouseId = warehouse.WarehouseId;
                shelf.WarehouseName = warehouse.Name;
            }

            shelf.Name = shelfDto.Name;
            shelf.Column = shelfDto.Column;
            shelf.Row = shelfDto.Row;

            _context.Entry(shelf).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShelfExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: api/Shelf/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShelf(string id)
        {
            var shelf = await _context.Shelves.FindAsync(id);
            if (shelf == null)
            {
                return NotFound();
            }

            _context.Shelves.Remove(shelf);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShelfExists(string id)
        {
            return _context.Shelves.Any(e => e.ShelfId == id);
        }
    }

    // DTO for creating/updating shelves
    
}