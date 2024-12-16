using Domain.Interfaces;
using BusinessLogic.Services;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace projectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentRateController : ControllerBase
    {
        private ICommentRateService _commentRateService;
        public CommentRateController(ICommentRateService commentRateService)
        {
            _commentRateService = commentRateService;
        }
       /// <summary>
       /// Полученне информации о всех оценках с комментариями
       /// </summary>
       /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _commentRateService.GetAll());
        }

        /// <summary>
        /// Получение информации об оценке по id
        /// </summary>
        /// <param name="id">Идентификатор оценки</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _commentRateService.GetById(id));
        }

        /// <summary>
        /// Создание новой оценки с комментарием
        /// </summary>
        /// <remarks>
        /// Пример запроса: 
        ///     
        ///     POST /Todo
        ///     {
        ///         "commentId": 10,
        ///         "userId": 5,
        ///         "rating": 7,
        ///         "createdDateTime": "2024-10-23T11:08:35.167Z"
        ///        
        ///     }
        ///     
        /// </remarks>
        /// <param name="commentRate">Оценка</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CommentRate commentRate)
        {
            await _commentRateService.Create(commentRate);
            return Ok();
        }

        /// <summary>
        /// Изменение информации оценки
        /// </summary>
        /// <remarks>
        /// Пример запроса: 
        ///     
        ///     POST /Todo
        ///     {
        ///         "commentId": 10,
        ///         "userId": 5,
        ///         "rating": 10,
        ///         "createdDateTime": "2024-10-23T11:08:35.167Z",
        ///         "updatedDateTime": "2024-10-23T12:11:23.251Z"
        ///     }
        ///     
        /// </remarks>
        /// <param name="commentRate">Оценка</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(CommentRate commentRate)
        {
            await _commentRateService.Update(commentRate);
            return Ok();
        }

        /// <summary>
        /// Удаление оценки
        /// </summary>
        /// <param name="id">Идентификатор оценки</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _commentRateService.Delete(id);
            return Ok();
        }
    }
}
