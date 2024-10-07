using BusinessLogic.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace projectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesUserController : ControllerBase
    {
        private IMessagesUserService _messagesUserService;
        public MessagesUserController(IMessagesUserService messagesUserService)
        {
            _messagesUserService = messagesUserService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _messagesUserService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _messagesUserService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(MessagesUser MessagesUser)
        {
            await _messagesUserService.Create(MessagesUser);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(MessagesUser MessagesUser)
        {
            await _messagesUserService.Update(MessagesUser);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _messagesUserService.Delete(id);
            return Ok();
        }
    }
}
