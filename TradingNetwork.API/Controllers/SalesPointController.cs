using CRUD.API.Handlers.CURDHandlers.ProvidedProductHandlers;
using CRUD.API.Handlers.CURDHandlers.ProvidedProductHanlders;
using CRUD.API.Handlers.CURDHandlers.SalesPointHandlers;
using Microsoft.AspNetCore.Mvc;
using Shared.Commands.ProvidedProductCommands;
using Shared.Commands.SalesPointCommands;
using Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingNetwork.API.Data;

namespace TradingNetwork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesPointController : ControllerBase
    {
        private readonly TradingNetworkContext _context;

        public SalesPointController(TradingNetworkContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<SalesPoint> Get()
        {
            return _context.SalesPoints;
        }

        [HttpGet("{id}")]
        public SalesPoint Get(int id)
        {
            return _context.SalesPoints.Where(x => x.Id == id).FirstOrDefault();
        }

        [HttpPost]
        public async Task Post([FromBody] CreateSalesPointCommand value)
        {
            var handler = new CreateSalesPointCommandHandler(_context);
            await handler.Create(value);
        }

        [HttpPut]
        public async Task Put([FromBody] UpdateSalesPointCommand value)
        {
            var handler = new UpdateSalesPointCommandHandler(_context);
            await handler.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (_context.SalesPoints.Where(x => x.Id == id).Any())
            {
                _context.Remove(_context.SalesPoints.Where(x => x.Id == id).FirstOrDefault());
                _context.SaveChanges();
            }
        }

        //ProvidedProducts

        [HttpGet("ProvidedProducts")]
        public IEnumerable<ProvidedProduct> GetPProducts()
        {
            return _context.ProvidedProducts;
        }

        [HttpGet("{id}/ProvidedProducts")]
        public IEnumerable<ProvidedProduct> GetPProducts(int id)
        {
            return _context.ProvidedProducts.Where(x => x.SalesPointId == id);
        }

        [HttpPost("ProvidedProducts")]
        public async Task PostPProducts([FromBody] CreateProvidedProductCommand value)
        {
            var handler = new CreateProvidedProductsCommandHandler(_context);
            await handler.Create(value);
        }

        [HttpPut("ProvidedProducts")]
        public async Task PutPProduct([FromBody] UpdateProvidedProductCommand value)
        {
            var handler = new UpdateProvidedProductsCommandHandler(_context);
            await handler.Update(value);
        }

        [HttpDelete("{id}/ProvidedProducts/{pid}")]
        public void Delete(int id, int pid)
        {
            if (_context.ProvidedProducts.Where(x => x.SalesPointId == id && x.ProductId == pid).Any())
            {
                _context.Remove(_context.ProvidedProducts
                    .Where(x => x.SalesPointId == id && x.ProductId == pid)
                    .FirstOrDefault());

                _context.SaveChanges();
            }
        }
    }
}
