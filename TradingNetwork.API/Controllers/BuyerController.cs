using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingNetwork.API.Data;
using Shared.Commands.BuyerCommands;
using CRUD.API.Handlers.CURDHandlers.BuyerHandlers;
using CRUD.API.Handlers.CURDHandlers.SaleIdsHandlers;
using Shared.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TradingNetwork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyerController : ControllerBase
    {
        private readonly TradingNetworkContext _context;

        public BuyerController(TradingNetworkContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Buyer> Get()
        {
            return _context.Buyers;
        }

        [HttpGet("{id}")]
        public Buyer Get(int id)
        {
            return _context.Buyers.Where(x => x.Id == id).FirstOrDefault();
        }

        [HttpPost]
        public async Task Post([FromBody] CreateBuyerCommand value)
        {
            var handler = new CreateBuyerCommandHandler(_context);
            await handler.Create(value);
        }

        [HttpPut]
        public async Task Put([FromBody] UpdateBuyerCommand value)
        {
            var handler = new UpdateBuyerCommandHandler(_context);
            await handler.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (_context.Buyers.Where(x => x.Id == id).Any())
            {
                _context.Remove(_context.Buyers.Where(x => x.Id == id).FirstOrDefault());
                _context.SaveChanges();
            }
        }

        //SalesIds

        [HttpGet("{id}/SalesIds")]
        public IEnumerable<int> GetSalesIds(int id)
        {
            return _context.Buyers.Include(x=>x.SalesIds).Where(x => x.Id == id).FirstOrDefault().SalesIds.Select(x => x.Id);
        }

        [HttpHead("SalesIds")]
        public async Task PostSalesIds()
        {
            var handler = new UpdateSalesIdsCommandHandler(_context);
            await handler.Update();
        }

    }
}
