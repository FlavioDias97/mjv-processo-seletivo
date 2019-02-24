using MarketplaceAPI.Model;
using MarketplaceAPI.Business.Implementattions;
using Microsoft.AspNetCore.Mvc;

namespace MarketplaceAPI.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/stores")]
    [ApiController]
    public class StoresController : ControllerBase
    {

        private IStoreBusiness _storeBusiness;
        public StoresController(IStoreBusiness storeBusiness)
        {
            _storeBusiness = storeBusiness;
        }

        // GET api/stores
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {
            return Ok(_storeBusiness.FindAll());
        }

        // GET api/stores/5
        [HttpGet("v1/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get(int id)
        {
            var store = _storeBusiness.FindById(id);
            if (store == null) return NotFound(); 
            return Ok(store);
        }

        // POST api/stores
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody]Store store)
        {
            if (store == null) return BadRequest();
            return new ObjectResult(_storeBusiness.Create(store));
        }

        // PUT api/stores/5
        [HttpPut("v1/")]
        [ProducesResponseType(202)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Put([FromBody]Store store)
        {
            if (store == null) return BadRequest();
            var updatedStore = _storeBusiness.Update(store);
            if (updatedStore == null) return NoContent();
            return new ObjectResult(updatedStore);
        }

        // DELETE api/stores/5
        [HttpDelete("v1/{id}")]
        [ProducesResponseType(202)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(int id)
        {
            _storeBusiness.Delete(id);
            return NoContent();
        }
    }
}
