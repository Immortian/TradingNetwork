using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TradingNetwork.API.Data;
using TradingNetwork.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TradingNetwork.API.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
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
        public void Post([FromBody] Product value)
        {
            _context.Products.Add(value);
            _context.SaveChanges();
        }

        [HttpPut]
        public void Put([FromBody] Product value)
        {
            _context.Update(value);
            _context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _context.Remove(_context.Products.Where(x => x.Id == id).FirstOrDefault());
            _context.SaveChanges();
        }
    }
}
