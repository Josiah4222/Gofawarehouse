using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gofabackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gofabackend.Data;
using Gofabackend.Models;


namespace Gofabackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterCardController : ControllerBase
    {
        // private readonly AppDbContext _context;
        private readonly ApplicationDbContext _context;

        public MasterCardController(ApplicationDbContext context)
        {
            _context = context;
        }



        // GET: api/MasterCard
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MasterCard>>> GetMasterCards()
        {
            return await _context.MasterCard.ToListAsync();
        }


        // GET: api/MasterCard/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MasterCard>> GetMasterCard(int id)
        {
            var masterCard = await _context.MasterCard.FindAsync(id);

            if (masterCard == null)
            {
                return NotFound();
            }

            return masterCard;
        }

        // POST: api/MasterCard
        [HttpPost]
        public async Task<ActionResult<MasterCard>> PostMasterCard(MasterCard masterCard)
        {
            _context.MasterCard.Add(masterCard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMasterCard", new { id = masterCard.MasterCardId }, masterCard);
        }

        // PUT: api/MasterCard/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMasterCard(int id, MasterCard masterCard)
        {
            if (id != masterCard.MasterCardId)
            {
                return BadRequest();
            }

            _context.Entry(masterCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MasterCardExists(id))
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

        // DELETE: api/MasterCard/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMasterCard(int id)
        {
            var masterCard = await _context.MasterCard.FindAsync(id);
            if (masterCard == null)
            {
                return NotFound();
            }

            _context.MasterCard.Remove(masterCard);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MasterCardExists(int id)
        {
            return _context.MasterCard.Any(e => e.MasterCardId == id);
        }
    }
}
