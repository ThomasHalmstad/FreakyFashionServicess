using FreakyFashionServices.Gateway.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace FreakyFashionServices.Gateway.Controllers
{
    [ApiController]
    public class GatewayController : ControllerBase
    {
        private readonly IHttpClientFactory clientFactory;

        public GatewayController(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        [HttpGet]
        [Route("api/items")]
        public async Task<ItemDto> GetItems()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "http://freakyfashionservices.catalog/api/catalog/items");

            request.Headers.Add("Accept", "application/json");

            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            var serializedItems = await response.Content.ReadAsStringAsync();

            var serializedOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };

            var itemsDto = JsonSerializer.Deserialize<ItemDto>(serializedItems, serializedOptions);

            return itemsDto;
        }

    }
}
