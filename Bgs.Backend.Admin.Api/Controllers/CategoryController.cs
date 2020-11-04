using Bgs.Backend.Admin.Api.Models.Category;
using Bgs.Bll.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bgs.Backend.Admin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("addArtist")]
        public IActionResult AddArtist(AddCategoryModel model)
        {
            _categoryService.AddArtist(model.Name);
            return Ok();
        }

        [HttpPost("deleteArtist")]
        public IActionResult DeleteArtist(DeleteCategoryModel model)
        {
            _categoryService.DeleteArtist(model.Id.Value);
            return Ok();
        }

        [HttpGet("getArtists")]
        public IActionResult GetArtists()
        {
            var artists = _categoryService.GetArtists();
            return Ok(artists);
        }

        [HttpPost("addDesigner")]
        public IActionResult AddDesigner(AddCategoryModel model)
        {
            _categoryService.AddDesigner(model.Name);
            return Ok();
        }

        [HttpPost("deleteDesigner")]
        public IActionResult DeleteDesigner(DeleteCategoryModel model)
        {
            _categoryService.DeleteDesigner(model.Id.Value);
            return Ok();
        }

        [HttpGet("getDesigners")]
        public IActionResult GetDesigners()
        {
            var designers = _categoryService.GetDesigners();
            return Ok(designers);
        }
    }
}