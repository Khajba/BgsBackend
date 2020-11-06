using Bgs.Bll.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Bgs.Backend.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("getArtists")]
        public IActionResult GetArtists()
        {
            var artists = _categoryService.GetArtists();
            return Ok(artists);
        }

        [HttpGet("getDesigners")]
        public IActionResult GetDesogners()
        {
            var desginers = _categoryService.GetDesigners();
            return Ok(desginers);
        }

        [HttpGet("getMechanics")]
        public IActionResult GetMechanics()
        {
            var mechanics = _categoryService.GetMechanics();
            return Ok(mechanics);
        }
    }
}
