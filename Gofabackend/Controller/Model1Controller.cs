using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gofabackend.Data;
using Gofabackend.Models;

namespace UserManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Model1Controller : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public Model1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Model1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Model1>>> GetModel1()
        {
            return await _context.Model1.ToListAsync();
        }

        // GET: api/Model1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Model1>> GetModel1(int id)  // Changed 'string id' to 'int id'
        {
            var model1 = await _context.Model1.FindAsync(id);

            if (model1 == null)
            {
                return NotFound();
            }

            return model1;
        }

        // PUT: api/Model1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModel1(int id, Model1 model1)  // Changed 'string id' to 'int id'
        {
            if (id != model1.Model1Id)
            {
                return BadRequest();
            }

            _context.Entry(model1).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Model1Exists(id))  // Changed 'string id' to 'int id'
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Model1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Model1>> PostModel1(Model1 model1)
        {
            _context.Model1.Add(model1);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Model1Exists(model1.Model1Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetModel1", new { id = model1.Model1Id }, model1);
        }

        // DELETE: api/Model1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModel1(int id)  // Changed 'string id' to 'int id'
        {
            var model1 = await _context.Model1.FindAsync(id);
            if (model1 == null)
            {
                return NotFound();
            }

            _context.Model1.Remove(model1);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Model1Exists(int id)  // Changed 'string id' to 'int id'
        {
            return _context.Model1.Any(e => e.Model1Id == id);
        }
    }
}