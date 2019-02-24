using MarketplaceAPI.Model;
using MarketplaceAPI.Business.Implementattions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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

        /// <summary>
        /// Get all Products in database
        /// </summary>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize("Bearer")]
        public IActionResult Get()
        {
            return Ok(_productBusiness.FindAll());
        }

        /// <summary>
        /// Get specific product by ID
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [Authorize("Bearer")]
        public IActionResult Get(int id)
        {
            var product = _productBusiness.FindById(id);
            if (product == null) return NotFound(); 
            return Ok(product);
        }

        /// <summary>
        /// Find by product by any term. Example (ttribute: Category, Term: Hardware)
        /// </summary>
        [HttpGet("{atrribute}/{term}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [Authorize("Bearer")]
        public IActionResult FindByTerm(string atrribute, string term)
        {
            //Attribute and term canot be null
            if (atrribute == null || term == null) return BadRequest();
            string entity = "products"; //hardcoded entity for generic method
            var product = _productBusiness.FindByTerm(entity,atrribute,term);
            if (product == null) return NotFound();
            return Ok(product);
        }

        /// <summary>
        /// Create new product
        /// </summary>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize("Bearer")]
        public IActionResult Post([FromBody]Product product)
        {
            if (product == null) return BadRequest();
            return new ObjectResult(_productBusiness.Create(product));
        }

        /// <summary>
        /// Change values ​​from a existing product
        /// </summary>
        [HttpPut]
        [ProducesResponseType(202)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize("Bearer")]
        public IActionResult Put([FromBody]Product product)
        {
            if (product == null) return BadRequest();
            var updatedProduct = _productBusiness.Update(product);
            if (updatedProduct == null) return NoContent();
            return new ObjectResult(updatedProduct);
        }

        /// <summary>
        /// Delete product by Id
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(202)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize("Bearer")]
        public IActionResult Delete(int id)
        {
            _productBusiness.Delete(id);
            return NoContent();
        }
    }
}
