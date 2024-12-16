using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace projectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyRatingController : ControllerBase
    {
        private IMyRatingService _myRatingService;
        public MyRatingController(IMyRatingService myRatingService)
        {
            _myRatingService = myRatingService;
        }
        /// <summary>
        /// Получение информации о всех личных оценках
        /// </summary>
        /// <returns></returns>
        
        // GET api/<MyRatingController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _myRatingService.GetAll());
        }

        /// <summary>
        /// Получение информации о оценках пользователя по id
        /// </summary>
        /// <param name="id">Идентификатор оценки</param>
        /// <returns></returns>

        // GET api/<MyRatingController>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _myRatingService.GetById(id));
        }

        /// <summary>
        /// Создание новой личной оценки 
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///      POST /Todo
        ///      {
        ///          "ratingId": 6,
        ///          "userId": 2, 
        ///          "mediaId": 1,
        ///          "rating": 10,
        ///          "createdDateTime": "2024-10-22T09:07:05.
        ///      }
        ///      
        /// </remarks>
        /// <param name="myRating">Личная оценка</param>
        /// <returns></returns>

        // POST api/<MyRatingController>
        [HttpPost]
        public async Task<IActionResult> Add(MyRating myRating)
        {
            await _myRatingService.Create(myRating);
            return Ok();
        }

        /// <summary>
        /// Изменение информации о личной оценке
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///      PUT /Todo
        ///      {
        ///          "ratingId": 6,
        ///          "userId": 2, 
        ///          "mediaId": 1,
        ///          "rating": 1,
        ///          "createdDateTime": "2024-10-22T10:07:05.
        ///      }
        ///      
        /// </remarks>
        /// <param name="myRating">Личная оценка</param>
        /// <returns></returns>\

        // PUT api/<MyRatingController>
        [HttpPut]
        public async Task<IActionResult> Update(MyRating myRating)
        {
            await _myRatingService.Update(myRating);
            return Ok();
        }

        /// <summary>
        /// Удаление личной оценки
        /// </summary>
        /// <param name="id">Идентификатор оценки</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _myRatingService.Delete(id);
            return Ok();
        }
    }
}
