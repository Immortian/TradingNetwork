using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaleAPI.Commands;
using Shared.Models;
using System.Threading.Tasks;

namespace SaleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        [HttpPost]
        public async Task Post([FromBody] SaleCommand value)
        {
            var handler = new SaleCommandHandler(this.HttpContext);
            await handler.GenerateSale(value);
        }
    }
}
