using Microsoft.AspNetCore.Mvc;
using WebApiAngularProject.Model;
using WebApiAngularProject.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiAngularProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService service;
        public CategoryController(ICategoryService service)
        {
            this.service = service;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        [Route("GetCategorys")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var list = await service.GetCategories();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET api/<CategoryController>/5
        [HttpGet]
        [Route("GetCategoryById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var model = await service.GetCategoryById(id);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST api/<CategoryController>
        [HttpPost]
        [Route("AddCategory")]
        public async Task<IActionResult> Post([FromBody][Bind(include: "CategoryName")] Category category)
        {
            try
            {
                var result = await service.AddCategory(category);
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

        // PUT api/<CategoryController>/5
        [HttpPut]
        [Route("UpdateCategory")]
        public async Task<IActionResult> Put([FromBody] Category category)
        {
            try
            {
                var result = await service.UpdateCategory(category);
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

        // DELETE api/<CategoryController>/5
        [HttpDelete]
        [Route("DeleteCategory/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await service.DeleteCategory(id);
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
