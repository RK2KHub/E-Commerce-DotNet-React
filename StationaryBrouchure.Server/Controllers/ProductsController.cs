using Microsoft.AspNetCore.Mvc;
using StationaryBrouchure.Server.Data;  // Add this to reference the ApplicationDbContext
using StationaryBrouchure.Server.Models;  // Add this to reference the Product model
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;  // For async DB operations

namespace StationaryBrouchure.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;  // Inject the ApplicationDbContext

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/products
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            // Query the products from the database
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }

        // GET: api/products/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            // Query the product by ID
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound(); // Return 404 if the product is not found
            }

            return Ok(product);
        }
    }
}
