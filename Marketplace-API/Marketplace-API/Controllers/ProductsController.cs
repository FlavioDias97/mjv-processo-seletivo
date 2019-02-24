using MarketplaceAPI.Model;
using MarketplaceAPI.Business.Implementattions;
using Microsoft.AspNetCore.Mvc;

namespace MarketplaceAPI.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private IProductBusiness _productBusiness;
        public ProductsController(IProductBusiness productBusiness)
        {
            _productBusiness = productBusiness;
        }

        // GET api/products
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_productBusiness.FindAll());
        }

        // GET api/products/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _productBusiness.FindById(id);
            if (product == null) return NotFound(); 
            return Ok(product);
        }

        // POST api/products
        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            if (product == null) return BadRequest();
            return new ObjectResult(_productBusiness.Create(product));
        }

        // PUT api/products/5
        [HttpPut("")]
        public IActionResult Put([FromBody]Product product)
        {
            if (product == null) return BadRequest();
            return new ObjectResult(_productBusiness.Update(product));
        }

        // DELETE api/products/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productBusiness.Delete(id);
            return NoContent();
        }
    }
}
