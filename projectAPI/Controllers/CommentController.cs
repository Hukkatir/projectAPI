using Domian.Interfaces;
using Domian.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace projectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private ICommentService _commenService;
        public CommentController(ICommentService commenService)
        {
            _commenService = commenService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _commenService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _commenService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(Comment comment)
        {
            await _commenService.Create(comment);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Comment comment)
        {
            await _commenService.Update(comment);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _commenService.Delete(id);
            return Ok();
        }
    }
}
