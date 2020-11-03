using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bgs.Bll.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bgs.Backend.Admin.Api.Controllers
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
        [HttpPost("AddArtist")]
        public IActionResult AddArtist([FromBody] string name)
        {
            _categoryService.AddArtist(name);
            return Ok();
        }

        [HttpPost("DeleteArtist")]
        public IActionResult DeleteArtist([FromBody] int Id)
        {
            _categoryService.DeleteArtist(Id);
            return Ok();
        }

        [HttpGet("GetArtists")]
        public IActionResult GetArtists()
        {
            var artists = _categoryService.GetArtists();
            return Ok(artists);
        }

        [HttpPost("AddDesigner")]
        public IActionResult AddDesigner([FromBody] string name)
        {
            _categoryService.AddDesigner(name);
            return Ok();
        }

        [HttpPost("DeleteDesigner")]
        public IActionResult DeleteDesigner([FromBody] int Id)
        {
            _categoryService.DeleteDesigner(Id);
            return Ok();
        }

        [HttpGet("GetDesigners")]
        public IActionResult GetDesigners()
        {
            var designers = _categoryService.GetDesigners();
            return Ok(designers);
        }

    }
}
