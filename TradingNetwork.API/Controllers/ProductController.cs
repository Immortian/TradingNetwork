using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingNetwork.API.Commands.CURDCommands.ProductCommands.CreateProductCommand;
using TradingNetwork.API.Commands.CURDCommands.ProductCommands.UpdateProductCommand;
using TradingNetwork.API.Data;
using TradingNetwork.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TradingNetwork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly TradingNetworkContext _context;

        public ProductController(TradingNetworkContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _context.Products;
        }

        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _context.Products.Where(x => x.Id == id).FirstOrDefault();
        }

        [HttpPost]
        public async Task Post([FromBody] CreateProductCommand value)
        {
            var handler = new CreateProductCommandHandler(_context);
            await handler.Create(value);
        }

        [HttpPut]
        public async Task Put([FromBody] Product value)
        {
            var handler = new UpdateProductComandHandler(_context);
            await handler.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (_context.Products.Where(x => x.Id == id).Any())
            {
                _context.Remove(_context.Products.Where(x => x.Id == id).FirstOrDefault());
                _context.SaveChanges();
            }
        }
    }
}
