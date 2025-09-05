using ATK_Business_API.Data;
using ATK_Business_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class TransactionsController : ControllerBase
{
    private readonly AppDbContext _context;

    public TransactionsController(AppDbContext context)
    {
        _context = context;
    }

    // READ: GET /api/transactions
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BusinessLedger>>> GetTransactions()
    {
        return await _context.BusinessLedger.OrderByDescending(t => t.TransactionDate).ToListAsync();
    }

    // CREATE: POST /api/transactions
    [HttpPost]
    public async Task<ActionResult<BusinessLedger>> PostTransaction(BusinessLedger transaction)
    {
        _context.BusinessLedger.Add(transaction);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetTransaction), new { id = transaction.LedgerId }, transaction);
    }

    // READ: GET /api/transactions/5
    [HttpGet("{id}")]
    public async Task<ActionResult<BusinessLedger>> GetTransaction(int id)
    {
        var transaction = await _context.BusinessLedger.FindAsync(id);
        if (transaction == null)
        {
            return NotFound();
        }
        return transaction;
    }

    // UPDATE: PUT /api/transactions/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTransaction(int id, BusinessLedger transaction)
    {
        if (id != transaction.LedgerId)
        {
            return BadRequest();
        }
        _context.Entry(transaction).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    // DELETE: DELETE /api/transactions/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTransaction(int id)
    {
        var transaction = await _context.BusinessLedger.FindAsync(id);
        if (transaction == null)
        {
            return NotFound();
        }
        _context.BusinessLedger.Remove(transaction);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}