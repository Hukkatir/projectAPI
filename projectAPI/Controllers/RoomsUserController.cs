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

        /// <summary>
        /// Получение всех записей о присоединениях к комнатам
        /// </summary>
        /// <returns>Список всех записей о присоединениях к комнатам</returns>

        // GET api/<RoomsUserController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _roomsUserService.GetAll());
        }
        /// <summary>
        /// Получение записи о присоеденении к комнате по id комнаты и id пользователя 
        /// </summary>
        /// <param name="idRoom">Идентификатор комнаты</param>
        /// <param name="idUser">Идентификатор пользователя</param>
        /// <returns>Данные о присоединении к комнате</returns>

        // GET api/<RoomsUserController>
        [HttpGet("{{idRoom}}/{{idUser}}")]
        public async Task<IActionResult> GetById(int idRoom, int idUser)
        {
            return Ok(await _roomsUserService.GetById(idRoom, idUser));
        }
        /// <summary>
        /// Добавление присоединения нового пользователя к комнате 
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     POST /Todo
        ///     {
        ///        "joinedDateTime": "2024-10-11T12:31:58.873Z",
        ///        "roomId": 15,
        ///        "userId": 5
        ///     }
        ///
        /// </remarks>
        /// <param name="roomUser"></param>
        /// <returns></returns>

        // POST api/<RoomsUserController>
        [HttpPost]
        public async Task<IActionResult> Add(RoomsUser roomUser)
        {
            await _roomsUserService.Create(roomUser);
            return Ok();
        }

        /// <summary>
        /// Обновление записи присоединения пользователя к комнате
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     PUT /Todo
        ///     {
        ///        "joinedDateTime": "2024-10-11T12:31:58.873Z",
        ///        "roomId": 15,
        ///        "userId": 5
        ///     }
        ///
        /// </remarks>
        /// <param name="roomUser"></param>
        /// <returns></returns>
        /// 

        // PUT api/<RoomsUserController>
        [HttpPut]
        public async Task<IActionResult> Update(RoomsUser roomUser)
        {
            await _roomsUserService.Update(roomUser);
            return Ok();
        }


        /// <summary>
        /// Удаление данных присоединения пользователя к комнате
        /// </summary>
        /// <param name="idRoom">Идентификатор комнаты</param>
        /// <param name="idUser">Идентификатор пользователя</param>
        /// <returns></returns>

        // DELETE api/<RoomsUserController>
        [HttpDelete("{{idRoom}}/{{idUser}}")]
        public async Task<IActionResult> Delete(int idRoom, int idUser)
        {
            await _roomsUserService.Delete(idRoom, idUser);
            return Ok();
        }
    }
}
