using Microsoft.AspNetCore.Mvc;
using RecruitmentTask.Core;
using RecruitmentTask.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecruitmentTask.Pages.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _productRepository.GetAll();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            // sprawdzić czy musi być
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await _productRepository.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Product updateProduct)
        {
            // sprawdzić czy musi być
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await _productRepository.GetById(id);
            if(product == null)
            {
                return NotFound();
            }

            await _productRepository.Update(updateProduct);

            return NoContent();
        }

        // POST: api/Products
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Product addProduct)
        {
            // sprawdzić czy musi być
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await _productRepository.Add(addProduct);

            return CreatedAtAction("Get", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            // sprawdzić czy musi być
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            await _productRepository.Delete(id);

            return Ok();
        }
    }
}