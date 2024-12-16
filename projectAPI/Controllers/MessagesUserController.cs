using Domain.Interfaces;
using Domain.Models;
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

        /// <summary>
        /// Получение информации о всех сообщениях
        /// </summary>
        /// <returns></returns>

        // GET api/<MessageUserController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _messagesUserService.GetAll());
        }

        /// <summary>
        /// Получение информации о сообщении по id
        /// </summary>
        /// <param name="id">Идентификатор сообщения</param>
        /// <returns></returns>

        // GET api/<MessageUserController>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _messagesUserService.GetById(id));
        }

        /// <summary>
        /// Создание нового сообщения
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///       "messageId": 50,
        ///       "userId": 10,
        ///       "roomId": 6,
        ///       "statusMessageId": 1,
        ///       "sendingDate": "2024-10-22T09:16:19.373Z",
        ///       "messageText": "hello there!"
        ///     }
        ///
        /// </remarks>
        /// <param name="MessagesUser">Пользователь</param>
        /// <returns></returns>

        // POST api/<MessageUserController>
        [HttpPost]
        public async Task<IActionResult> Add(MessagesUser MessagesUser)
        {
            await _messagesUserService.Create(MessagesUser);
            return Ok();
        }

        /// <summary>
        /// Изменение информации о сообщении
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///       "messageId": 50,
        ///       "userId": 10,
        ///       "roomId": 6,
        ///       "statusMessageId": 1,
        ///       "sendingDate": "2024-10-22T09:16:19.373Z",
        ///       "messageText": "bye there!",
        ///     }
        ///
        /// </remarks>
        /// <param name="MessagesUser">Пользователь</param>
        /// <returns></returns>

        // PUT api/<MessageUserController>
        [HttpPut]
        public async Task<IActionResult> Update(MessagesUser MessagesUser)
        {
            await _messagesUserService.Update(MessagesUser);
            return Ok();
        }
        /// <summary>
        /// Удаление сообщения 
        /// </summary>
        /// <param name="id">Идентификатор сообщения</param>
        /// <returns></returns>

        // DELETE api/<MessageUserController>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _messagesUserService.Delete(id);
            return Ok();
        }
    }
}
