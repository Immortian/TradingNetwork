using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingNetwork.API.Commands.CreateCommands;
using TradingNetwork.API.Commands.UpdateCommands;
using TradingNetwork.API.Data;
using TradingNetwork.API.Models;

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
        public void Post([FromBody] CreateSalesPointCommand value)
        {
            var product = new SalesPoint
            {
                Name = value.Name
            };
            _context.SalesPoints.Add(product);
            _context.SaveChanges();
        }

        [HttpPut]
        public void Put([FromBody] UpdateSalesPointCommand value)
        {
            if (_context.SalesPoints.Where(x => x.Id == value.Id).Any())
            {
                var current = _context.SalesPoints.Where(x => x.Id == value.Id).FirstOrDefault();
                current.Name = value.Name;
                _context.Update(current);
                _context.SaveChanges();
            }
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
        public void PostPProducts([FromBody] CreateProvidedProductCommand value)
        {
            var product = new ProvidedProduct
            {
                ProductId = value.ProductId,
                SalesPointId = value.SalesPointId,
                ProductQuantity = value.ProductQuantity
            };
            _context.ProvidedProducts.Add(product);
            _context.SaveChanges();
        }

        [HttpPut("ProvidedProducts")]
        public void PutPProduct([FromBody] UpdateProvidedProductCommand value)
        {
            if (_context.ProvidedProducts.Where(x => x.SalesPointId == value.SalesPointId 
                                                  && x.ProductId == value.ProductId).Any())
            {
                var current = _context.ProvidedProducts
                    .Where(x => x.SalesPointId == value.SalesPointId
                        && x.ProductId == value.ProductId)
                    .FirstOrDefault();

                current.ProductQuantity = value.ProductQuantity;

                _context.Update(current);
                _context.SaveChanges();
            }
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
