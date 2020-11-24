using Bgs.Bll.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Net.Mime;

namespace Bgs.Backend.Multimedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly string _fileSystemPath;
        private readonly IMultimediaService _multimediaService;

        public ImageController(IConfiguration configuration, IMultimediaService multimediaService)
        {
            _fileSystemPath = configuration["FileSystemPath"];
            _multimediaService = multimediaService;
        }

        [HttpPost("add")]
        public IActionResult Add(IFormFile file)
        {
            var attachmentUrl = _multimediaService.AddImage(file);

            return Ok(attachmentUrl);
        }

        [HttpGet("get")]
        public IActionResult GetAttachment(string fileName)
        {
            var filePath = Path.Combine($"{_fileSystemPath}/UploadedImages", fileName);

            return PhysicalFile(filePath, MediaTypeNames.Image.Jpeg);
        }
    }
}