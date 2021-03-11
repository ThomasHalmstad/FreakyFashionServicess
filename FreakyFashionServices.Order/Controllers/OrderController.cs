using FreakyFashionServices.Basket.Models;
using FreakyFashionServices.Order.Models.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace FreakyFashionServices.Order.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderContext _context;
        private readonly IHttpClientFactory clientFactory;
        public OrderController(OrderContext context, IHttpClientFactory clientFactory)
        {
            _context = context;
            this.clientFactory = clientFactory;
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder(Models.Order order)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "http://freakyfashionservices.basket/api/basket/" + order.CustomerIdentifier);

            request.Headers.Add("Accept", "application/json");

            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            var serializedBasket = await response.Content.ReadAsStringAsync();

            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };

            var basket = JsonSerializer.Deserialize<Basket>(serializedBasket, serializeOptions);

            foreach (var item in basket.Items)
            {
                order.Items.Add(item);
            }

            _context.Order.Add(order);
            _context.SaveChanges();

            return Ok();
        }

        internal class Basket
        {
            public int Id { get; set; }
            public IList<Item> Items { get; set; }
        }
    }
}
