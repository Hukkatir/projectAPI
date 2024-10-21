using Domain.Models;
using Domian.Interfaces;
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
        /// <summary>
        /// Получение данных о присоеденениях к команте по id команты и id пользователя 
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     {
        ///         "idRoom" : 1,
        ///         "idUser" : 5
        ///     }
        ///
        /// </remarks>
        /// <param name="idRoom"></param>
        /// <param name="idUser"></param>
        /// <returns></returns>

        [HttpGet("{{idRoom}}/{{idUser}}")]
        public async Task<IActionResult> GetById(int idRoom, int idUser)
        {
            return Ok(await _roomsUserService.GetById(idRoom, idUser));
        }
        /// <summary>
        /// Прислоединение нового пользователя к комнате 
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     {
        ///        "joinedDateTime": "2024-10-11T12:31:58.873Z",
        ///        "roomId": 15,
        ///        "userId": 5
        ///     }
        ///
        /// </remarks>
        /// <param name="roomUser"></param>
        /// <returns></returns>
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

        [HttpDelete("{{idRoom}}/{{idUser}}")]
        public async Task<IActionResult> Delete(int idRoom, int idUser)
        {
            await _roomsUserService.Delete(idRoom, idUser);
            return Ok();
        }
    }
}
