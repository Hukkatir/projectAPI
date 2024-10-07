using BusinessLogic.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace projectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private IContentService _contentService;
        public ContentController(IContentService contentService)
        {
            _contentService = contentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _contentService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _contentService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(Content content)
        {
            await _contentService.Create(content);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Content content)
        {
            await _contentService.Update(content);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _contentService.Delete(id);
            return Ok();
        }
    }
}
