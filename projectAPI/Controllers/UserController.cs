using Domain.Interfaces;
using Domain.Models;
using Domian.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace projectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        /// <summary>
        /// Получение всех записей пользователей
        /// </summary>
        /// <remarks>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userService.GetAll());
        }

        /// <summary>
        /// Получение записи пользователя по id
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     {
        ///         "Id": 1
        ///     }
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _userService.GetById(id));
        }
        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///        "roleId": 1,
        ///        "username" : "hukkatir",
        ///        "userPassword" : "!Pa$$word123@",
        ///        "email" : "hukkatir@gmail/com"
        ///        "firstname" : "Иван",
        ///        "lastname" : "Иванов",
        ///        "middlename" : "Иванович"
        ///        "dateOfBirth" : "01.06.2006"
        ///        "createdBy": 1,
        ///        "createdAt": "2024-01-21T18:57:41.342Z"
        ///     }
        ///
        /// </remarks>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>

        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> Add(User user)
        {
            await _userService.Create(user);
            return Ok();
        }

        /// <summary>
        /// Обновление данных пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     {
        ///         "roleId": 2,
        ///         "username": "Hukkatir",
        ///         "userPassword": "12345",
        ///         "email": "Hukkatir@gmail.com",
        ///         "createdBy": 1,
        ///         "createdAt": "2024-01-21T18:57:41.342Z"
        ///     }
        ///
        /// </remarks>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(User user) 
        {
            await _userService.Update(user);
            return Ok();
        }
        /// <summary>
        /// Удаление данных пользователя по id
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     {
        ///         "Id": 6
        ///     }
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return Ok();
        }
    }
}

