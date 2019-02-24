using MarketplaceAPI.Model;
using MarketplaceAPI.Services.Implementattions;
using Microsoft.AspNetCore.Mvc;

namespace MarketplaceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {

        private IStoreService _storeService;
        public StoresController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_storeService.FindAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var store = _storeService.FindById(id);
            if (store == null) return NotFound(); 
            return Ok(store);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Store store)
        {
            if (store == null) return BadRequest();
            return new ObjectResult(_storeService.Create(store));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody]Store store)
        {
            if (store == null) return BadRequest();
            return new ObjectResult(_storeService.Update(store));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _storeService.Delete(id);
            return NoContent();
        }
    }
}
