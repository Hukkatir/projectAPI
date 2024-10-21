using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace projectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupMediumController : ControllerBase
    {
        private IGroupMediumService _groupMediumService;
        public GroupMediumController(IGroupMediumService groupMediumService)
        {
            _groupMediumService = groupMediumService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _groupMediumService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _groupMediumService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(GroupMedium GroupMedium)
        {
            await _groupMediumService.Create(GroupMedium);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(GroupMedium GroupMedium)
        {
            await _groupMediumService.Update(GroupMedium);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _groupMediumService.Delete(id);
            return Ok();
        }
    }
}

