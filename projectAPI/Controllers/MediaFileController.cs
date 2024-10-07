using Domian.Interfaces;
using Domian.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace projectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaFileController : ControllerBase
    {
        private IMediaFileService _mediaFileService;
        public MediaFileController(IMediaFileService mediaFileService)
        {
            _mediaFileService = mediaFileService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediaFileService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _mediaFileService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(MediaFile mediafile)
        {
            await _mediaFileService.Create(mediafile);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(MediaFile mediafile)
        {
            await _mediaFileService.Update(mediafile);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediaFileService.Delete(id);
            return Ok();
        }
    }
}

