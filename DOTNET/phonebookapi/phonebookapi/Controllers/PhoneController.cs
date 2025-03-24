using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using phonebookapi.Data;
using phonebookapi.Models;

[Route("api/[controller]")]
[ApiController]
public class PhoneController : ControllerBase
{
    private readonly ProductDbContext _context;

    public PhoneController(ProductDbContext context)
    {
        _context = context;
    }

    // GET: api/phone
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        return await _context.Products.ToListAsync();
    }

    // GET: api/phone/name/{name}
    [HttpGet("name/{name}")]
    public async Task<ActionResult<Product>> GetProductByName(string name)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Name == name);
        if (product == null) return NotFound();
        return product;
    }

    // POST: api/phone
    [HttpPost]
    public async Task<ActionResult<Product>> PostProduct([FromBody] Product product)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProductByName), new { name = product.Name }, product);
    }

    // PUT: api/phone/name/{name}
    [HttpPut("name/{name}")]
    public async Task<IActionResult> PutProduct(string name, [FromBody] Product updatedProduct)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Name == name);
        if (product == null) return NotFound();

        product.email= updatedProduct.email; // Update relevant fields
        product.city = updatedProduct.city;

        _context.Entry(product).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    // DELETE: api/phone/name/{name}
    [HttpDelete("name/{name}")]
    public async Task<IActionResult> DeleteProduct(string name)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Name == name);
        if (product == null) return NotFound();

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
