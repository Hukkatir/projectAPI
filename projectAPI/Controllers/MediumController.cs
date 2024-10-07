using Domian.Interfaces;
using Domian.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace projectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediumController : ControllerBase
    {
        private IMediumService _mediumService;
        public MediumController(IMediumService mediumService)
        {
            _mediumService = mediumService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediumService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _mediumService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(Medium medium)
        {
            await _mediumService.Create(medium);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Medium medium)
        {
            await _mediumService.Update(medium);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediumService.Delete(id);
            return Ok();
        }
    }
}

