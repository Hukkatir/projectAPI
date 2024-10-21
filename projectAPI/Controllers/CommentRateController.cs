using Domain.Interfaces;
using BusinessLogic.Services;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace projectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentRateController : ControllerBase
    {
        private ICommentRateService _commentRateService;
        public CommentRateController(ICommentRateService commentRateService)
        {
            _commentRateService = commentRateService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _commentRateService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _commentRateService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CommentRate commentRate)
        {
            await _commentRateService.Create(commentRate);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(CommentRate commentRate)
        {
            await _commentRateService.Update(commentRate);
            return Ok();
        }   

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _commentRateService.Delete(id);
            return Ok();
        }
    }
}
