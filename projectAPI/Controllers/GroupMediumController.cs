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

        /// <summary>
        /// Получение информации о всех группах 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _groupMediumService.GetAll());
        }

        /// <summary>
        /// Получение информации о группе по id
        /// </summary>
        /// <param name="id">Идентификатор группы</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _groupMediumService.GetById(id));
        }

        /// <summary>
        /// Создание новой группы 
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     POST /Todo
        ///     {
        ///         "groupName": "9-1-1 1 сезон",
        ///         "groupDescrip": "Сериал расскажет о работе полицейских, «Скорой помощи» и пожарной службы. Все они выполняют свой долг, часто рискуя жизнью и попадая в самые пугающие и шокирующие ситуации. Смысл их ежедневной работы состоит в охране безопасности улиц и помощи всем, кто в ней нуждается."
        ///     }
        /// 
        /// </remarks>
        /// <param name="GroupMedium">Группа</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(GroupMedium GroupMedium)
        {
            await _groupMediumService.Create(GroupMedium);
            return Ok();
        }

        /// <summary>
        /// Изменение информацции о группе
        /// </summary>
        /// <remarks>
        /// Пример запроса: 
        ///     
        ///     PUT /Todo
        ///     {
        ///         "groupName": "9-1-1 1 сезон",
        ///         "groupDescrip": "Сериал расскажет о работе полицейских, «Скорой помощи» и пожарной службы. Все они выполняют свой долг, часто рискуя жизнью и попадая в самые пугающие и шокирующие ситуации. Смысл их ежедневной работы состоит в охране безопасности улиц и помощи всем, кто в ней нуждается."
        ///        
        ///     }
        ///     
        /// </remarks>
        /// <param name="GroupMedium">Группа</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(GroupMedium GroupMedium)
        {
            await _groupMediumService.Update(GroupMedium);
            return Ok();
        }

        /// <summary>
        /// Удаление группы
        /// </summary>
        /// <param name="id">Идентификатор группы</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _groupMediumService.Delete(id);
            return Ok();
        }
    }
}

