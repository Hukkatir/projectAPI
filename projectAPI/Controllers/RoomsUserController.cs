using BusinessLogic.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace projectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsUserController : ControllerBase
    {
        private IRoomsUserService _roomsUserService;
        public RoomsUserController(IRoomsUserService roomsUserService)
        {
            _roomsUserService = roomsUserService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _roomsUserService.GetAll());
        }

        [HttpGet("{idPayment}/{idUser}")]
        public async Task<IActionResult> GetById(int idRoom, int idUser)
        {
            return Ok(await _roomsUserService.GetById(idRoom, idUser));
        }

        [HttpPost]
        public async Task<IActionResult> Add(RoomsUser roomUser)
        {
            await _roomsUserService.Create(roomUser);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(RoomsUser roomUser)
        {
            await _roomsUserService.Update(roomUser);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int idRoom, int idUser)
        {
            await _roomsUserService.Delete(idRoom, idUser);
            return Ok();
        }
    }
}
