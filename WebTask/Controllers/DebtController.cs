using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebTask.Data;
using WebTask.Models;

namespace WebTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // путь контроллера, в данном случае debt
    public class DebtController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DebtController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Debt>>> GetDebts()  // ActionResult для получения кодов 200,500 и т.д.
        {
            return await _context.Debts.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Debt>> GetDebt(int id)
        {
            var debt = await _context.Debts.FindAsync(id);
            return debt == null ? NotFound() : Ok(debt); // вернет 404 если не найдет
        }

        [HttpPost]
        public async Task<ActionResult<Debt>> CreateDebt(Debt debt)
        {
            _context.Debts.Add(debt);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetDebt), new { id = debt.Id }, debt); // вернет 201 c сылкой на новый долг 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDebt(int id, Debt debt)
        {
            if (id != debt.Id) return BadRequest();
            _context.Entry(debt).State = EntityState.Modified; // пометит как измененный 
            await _context.SaveChangesAsync();
            return NoContent();                                // вернет 204, будет означать что выполнилось успешно, без ответа
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDebt(int id)
        {
            var debt = await _context.Debts.FindAsync(id);
            if (debt == null) return NotFound();

            _context.Debts.Remove(debt);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
