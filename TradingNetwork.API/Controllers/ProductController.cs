using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TradingNetwork.API.Commands.CreateCommands;
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
        public void Post([FromBody] CreateProductCommand value)
        {
            var product = new Product
            {
                Name = value.Name,
                Price = value.Price
            };
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        [HttpPut]
        public void Put([FromBody] Product value)
        {
            if (_context.Products.Where(x => x.Id == value.Id).Any())
            {
                _context.Update(value);
                _context.SaveChanges();
            }
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
