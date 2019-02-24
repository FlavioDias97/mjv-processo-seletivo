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
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {
            return Ok(_productBusiness.FindAll());
        }

        // GET api/products/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public IActionResult Get(int id)
        {
            var product = _productBusiness.FindById(id);
            if (product == null) return NotFound(); 
            return Ok(product);
        }

        // GET api/products/5
        [HttpGet("{atrribute}/{term}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public IActionResult FindByTerm(string atrribute, string term)
        {
            //Attribute and term canot be null
            if (atrribute == null || term == null) return BadRequest();
            string entity = "products"; //hardcoded entity for generic method
            var product = _productBusiness.FindByTerm(entity,atrribute,term);
            if (product == null) return NotFound();
            return Ok(product);
        }

        // POST api/products
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody]Product product)
        {
            if (product == null) return BadRequest();
            return new ObjectResult(_productBusiness.Create(product));
        }

        // PUT api/products/5
        [HttpPut]
        [ProducesResponseType(202)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Put([FromBody]Product product)
        {
            if (product == null) return BadRequest();
            var updatedProduct = _productBusiness.Update(product);
            if (updatedProduct == null) return NoContent();
            return new ObjectResult(updatedProduct);
        }

        // DELETE api/products/5
        [HttpDelete("{id}")]
        [ProducesResponseType(202)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(int id)
        {
            _productBusiness.Delete(id);
            return NoContent();
        }
    }
}
