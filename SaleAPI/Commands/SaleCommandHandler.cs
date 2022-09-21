using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RestSharp;
using Shared.Commands.ProvidedProductCommands;
using Shared.Commands.SaleCommands;
using Shared.Commands.SaleDataCommands;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleAPI.Commands
{
    public class SaleCommandHandler
    {
        private HttpContext _httpContext;
        private IEnumerable<ProvidedProduct> providedProducts;
        private RestClient client;
        public SaleCommandHandler(HttpContext httpContext)
        {
            _httpContext = httpContext;
            Uri baseUrl = new Uri("http://crud.api:80/api");
            client = new RestClient(baseUrl);
        }
        public async Task GenerateSale(SaleCommand request)
        {
            if (!IsProvidedProductsEnough(request.SalesPointId, request.SalesData))
                throw new ArgumentException("Not enough products");

            await RecalculateProvidedProducts(request.SalesPointId, request.SalesData);
            await SaveSale(request);
        }
        private bool IsProvidedProductsEnough(int salePointId, IEnumerable<CreateSaleDataCommand> requestSalesData)
        {
            var httpRequest = new RestRequest($"SalesPoint/{salePointId}/ProvidedProducts", Method.Get);
            var response = client.Execute(httpRequest);
            providedProducts = JsonConvert
                .DeserializeObject<IEnumerable<ProvidedProduct>>(response.Content);

            foreach (var data in requestSalesData)
            {
                var pProduct = providedProducts
                    .Where(x => x.ProductId == data.ProductId)
                    .FirstOrDefault();

                if (data.ProductQuantity > pProduct.ProductQuantity)
                {
                    return false;
                }
            }
            return true;
        }

        private async Task RecalculateProvidedProducts(int salePointId, IEnumerable<CreateSaleDataCommand> requestSalesData)
        {
            foreach(var data in requestSalesData)
            {
                var pProduct = providedProducts
                    .Where(x => x.ProductId == data.ProductId)
                    .FirstOrDefault();

                var httpRequest = new RestRequest($"SalesPoint/ProvidedProducts", Method.Put);
                httpRequest.AddJsonBody(
                    new UpdateProvidedProductCommand
                    {
                        ProductId = data.ProductId,
                        SalesPointId = salePointId,
                        ProductQuantity = pProduct.ProductQuantity - data.ProductQuantity
                    });
                await client.ExecuteAsync(httpRequest);
            }
        }

        private async Task SaveSale(SaleCommand request)
        {
            var saveSaleHttpRequest = new RestRequest($"Sale", Method.Post);
            saveSaleHttpRequest.AddJsonBody(
                new CreateSaleCommand
                {
                    SalesPointId = request.SalesPointId,
                    BuyerId = request.BuyerId,
                    DateTime = DateTime.Now
                });

            var response = await client.ExecuteAsync(saveSaleHttpRequest);

            var currentSale = (Sale)JsonConvert
                .DeserializeObject<Sale>(response.Content);

            foreach (var data in request.SalesData)
            {
                var saveSaleDataHttpRequest = new RestRequest($"Sale/SaleData", Method.Post);
                saveSaleDataHttpRequest.AddJsonBody(
                    new CreateSaleDataCommand
                    {
                        ProductId = data.ProductId,
                        ProductQuantity = data.ProductQuantity,
                        SaleId = currentSale.Id
                    });
                await client.ExecuteAsync(saveSaleDataHttpRequest);
            }
        }

    }
}
