using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace projectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _roomService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _roomService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(Room room)
        {
            await _roomService.Create(room);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Room room)
        {
            await _roomService.Update(room);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _roomService.Delete(id);
            return Ok();
        }
    }
}

