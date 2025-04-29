using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebTask.Data;
using WebTask.Models;

namespace WebTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PassportController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PassportController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Passport>>> GetPassports()
        {
            return await _context.Passports.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Passport>> GetPassport(int id)
        {
            var passport = await _context.Passports.FindAsync(id);
            return passport == null ? NotFound() : Ok(passport);
        }

        [HttpPost]
        public async Task<ActionResult<Passport>> CreatePassport(Passport passport)
        {
            _context.Passports.Add(passport);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPassport), new { id = passport.Id }, passport);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePassport(int id, Passport passport)
        {
            if (id != passport.Id) return BadRequest();
            _context.Entry(passport).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePassport(int id)
        {
            var passport = await _context.Passports.FindAsync(id);
            if (passport == null) return NotFound();

            _context.Passports.Remove(passport);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
