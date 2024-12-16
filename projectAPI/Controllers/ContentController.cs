using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace projectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private IContentService _contentService;
        public ContentController(IContentService contentService)
        {
            _contentService = contentService;
        }

        /// <summary>
        /// Получение информации о всем контенте 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _contentService.GetAll());
        }

        /// <summary>
        /// Получение информации о контенте по id
        /// </summary>
        /// <param name="id">Идентификатор контента</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _contentService.GetById(id));
        }

        /// <summary>
        /// Создание нового контента
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     POST /Todo
        ///     {
        ///         "authorId": 5, 
        ///         "mediaId": 10,
        ///         "categoryContentId": 3,
        ///         "title": "Провал Джокера 2",
        ///         "contentText": "В мировом прокате с оглушительным треском продолжает проваливаться «Джокер: Безумие на двоих». Продолжение хитового фильма 2019 года, который взял «Золотого льва» на Венецианском фестивале, а затем принес оскаровскую статуэтку Хоакину Фениксу, здорово разозлило фанатов и разочаровало критиков. Но все это часть плана Тодда Филлипса, который сам выступил в роли Джокера и провернул беспрецедентную акцию по уничтожению кинокомикса. Может, пора объяснить, почему «Безумие на двоих» вызывает восхищение несмотря ни на что?",
        ///         "createdBy": 1,
        ///         "createdDateTime": "2024-10-23T10:32:26.261Z"
        ///     }
        ///     
        /// </remarks>
        /// <param name="content">Контент</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(Content content)
        {
            await _contentService.Create(content);
            return Ok();
        }
        /// <summary>
        /// Изменение информации о контенте 
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     PUT /Todo
        ///     {
        ///         "authorId": 5, 
        ///         "mediaId": 10,
        ///         "categoryContentId": 3,
        ///         "title": "Вы не поймете! Почему сиквел «Джокера» — главный поп-культурный феномен года",
        ///         "contentText": "В мировом прокате с оглушительным треском продолжает проваливаться «Джокер: Безумие на двоих». Продолжение хитового фильма 2019 года, который взял «Золотого льва» на Венецианском фестивале, а затем принес оскаровскую статуэтку Хоакину Фениксу, здорово разозлило фанатов и разочаровало критиков. Но все это часть плана Тодда Филлипса, который сам выступил в роли Джокера и провернул беспрецедентную акцию по уничтожению кинокомикса. Может, пора объяснить, почему «Безумие на двоих» вызывает восхищение несмотря ни на что?",
        ///         "createdBy": 1,
        ///         "createdDateTime": "2024-10-23T10:32:26.261Z",
        ///         "updatedBy": 5,
        ///         "updatedDateTime": "2024-11-23T10:32:26.261Z"
        ///     }
        ///     
        /// </remarks>
        /// <param name="content">Контент</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(Content content)
        {
            await _contentService.Update(content);
            return Ok();
        }
        /// <summary>
        /// Удаление контента
        /// </summary>
        /// <param name="id">Идентификатор контента</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _contentService.Delete(id);
            return Ok();
        }
    }
}
