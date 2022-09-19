using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingNetwork.API.Commands.CURDCommands.SaleCommands.CreateSaleCommand;
using TradingNetwork.API.Commands.CURDCommands.SaleCommands.UpdateSaleCommand;
using TradingNetwork.API.Commands.CURDCommands.SaleDataCommands.CreateSaleDataCommand;
using TradingNetwork.API.Commands.CURDCommands.SaleDataCommands.UpdateSaleDataCommand;
using TradingNetwork.API.Data;
using TradingNetwork.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TradingNetwork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly TradingNetworkContext _context;

        public SaleController(TradingNetworkContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Sale> Get()
        {
            return _context.Sales;
        }

        [HttpGet("{id}")]
        public Sale Get(int id)
        {
            return _context.Sales.Where(x => x.Id == id).FirstOrDefault();
        }

        [HttpPost]
        public async Task Post([FromBody] CreateSaleCommand value)
        {
            var handler = new CreateSaleCommandHandler(_context);
            await handler.Create(value);
        }

        [HttpPut]
        public async void Put([FromBody] UpdateSaleCommand value)
        {
            var handler = new UpdateSaleCommandHandler(_context);
            await handler.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (_context.Sales.Where(x => x.Id == id).Any())
            {
                _context.Remove(_context.Sales.Where(x => x.Id == id).FirstOrDefault());
                _context.SaveChanges();
            }
        }

        //SaleData

        [HttpGet("SaleData")]
        public IEnumerable<SaleData> GetSaleData()
        {
            return _context.SaleDatas;
        }

        [HttpGet("{id}/SaleData")]
        public IEnumerable<SaleData> GetSaleData(int id)
        {
            return _context.SaleDatas.Where(x => x.SaleId == id);
        }

        [HttpPost("SaleData")]
        public async Task PostSaleData([FromBody] CreateSaleDataCommand value)
        {
            var handler = new CreateSaleDataCommandHandler(_context);
            await handler.Create(value);
        }

        [HttpPut("SaleData")]
        public async void PutSaleData([FromBody] UpdateSaleDataCommand value)
        {
            var handler = new UpdateSaleDataCommandHandler(_context);
            await handler.Update(value);
        }

        [HttpDelete("{id}/SaleData/{pid}")]
        public void DeleteSaleData(int id, int pid)
        {
            if (_context.Sales.Where(x => x.Id == id).Any())
            {
                _context.Remove(_context.Sales.Where(x => x.Id == id).FirstOrDefault());
                _context.SaveChanges();
            }
        }
    }
}
