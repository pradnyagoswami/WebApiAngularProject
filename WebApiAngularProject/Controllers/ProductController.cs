using Microsoft.AspNetCore.Mvc;
using WebApiAngularProject.Model;
using WebApiAngularProject.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiAngularProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService service;
        public ProductController(IProductService service)
        {
            this.service = service;
        }

        // GET: api/<ProductController>
        [HttpGet]
        [Route("GetProducts")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var list = await service.GetProducts();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET api/<ProductController>/5
        [HttpGet]
        [Route("GetProductById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var model = await service.GetProductById(id);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST api/<ProductController>
        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> Post([FromBody][Bind(include: "Productname,Productprice,CategoryId,ImageUrl")] Product product)
        {
            try
            {
                var result = await service.AddProduct(product);
                if (result >= 1)
                    return StatusCode(StatusCodes.Status201Created);
                else
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT api/<ProductController>/5
        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<IActionResult> Put([FromBody] Product product)
        {
            try
            {
                var result = await service.UpdateProduct(product);
                if (result >= 1)
                    return StatusCode(StatusCodes.Status201Created);
                else
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete]
        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await service.DeleteProduct(id);
                if (result >= 1)
                    return StatusCode(StatusCodes.Status201Created);
                else
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
