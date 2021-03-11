using FreakyFashionServices.Basket.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace FreakyFashionServices.Basket.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IDistributedCache cache;

        public BasketController(IDistributedCache cache)
        {
            this.cache = cache;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> CreateBasket(CreateBasketDto createBasketDto)
        {
            var options = new DistributedCacheEntryOptions();

            //options.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60);
            //options.SlidingExpiration = TimeSpan.FromSeconds(30);

            var serializedData = JsonSerializer.Serialize(createBasketDto);

            await cache.SetStringAsync(createBasketDto.Id.ToString(), serializedData, options);

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CreateBasketDto>> GetBasket(string id)
        {
            var serializedBasket = await cache.GetStringAsync(id);

            if (serializedBasket is null)
            {
                return NotFound();
            }

            var serializedDto = JsonSerializer.Deserialize<CreateBasketDto>(serializedBasket);

            return Ok(serializedDto);
        }
    }
}
