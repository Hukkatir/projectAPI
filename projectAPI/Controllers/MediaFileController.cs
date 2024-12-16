using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace projectAPI.Controllers
{
    /// <summary>
    /// Контроллер для управления медиафайлами
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MediaFileController : ControllerBase
    {
        private IMediaFileService _mediaFileService;
        public MediaFileController(IMediaFileService mediaFileService)
        {
            _mediaFileService = mediaFileService;
        }

        /// <summary>
        /// Получение информации о всех медиафайлах
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediaFileService.GetAll());
        }

        /// <summary>
        /// Получение медиафайла по id 
        /// </summary>
        /// <param name="id">Идентификатор медиафайла</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _mediaFileService.GetById(id));
        }

        /// <summary>
        /// Добавление нового медиафайла
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///     
        ///     POST /Todo
        ///     {
        ///         "mediaFileId": 5,
        ///         "mediaId": 1,
        ///         "fileId": 5,
        ///         "mediaFileName": "9-1-1_s08e01"
        ///     }
        /// 
        /// </remarks>
        /// <param name="mediafile">Медиафайл</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(MediaFile mediafile)
        {
            await _mediaFileService.Create(mediafile);
            return Ok();
        }


        /// <summary>
        /// Изменение информации о медиофайле
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///     
        ///     PUT /Todo
        ///     {
        ///         "mediaFileId": 5,
        ///         "mediaId": 1,
        ///         "fileId": 5,
        ///         "mediaFileName": "9-1-1_s08e02"
        ///     }
        /// 
        /// </remarks>
        /// <param name="mediafile">Медиафайл</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(MediaFile mediafile)
        {
            await _mediaFileService.Update(mediafile);
            return Ok();
        }

        /// <summary>
        /// Удаление медиафайла
        /// </summary>
        /// <param name="id">Идентификатор медиафайла</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediaFileService.Delete(id);
            return Ok();
        }
    }
}

