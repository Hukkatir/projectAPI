using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace projectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentUserController : ControllerBase
    {
        private IPaymentUserService _paymentUserService;
        public PaymentUserController(IPaymentUserService paymentUserService)
        {
            _paymentUserService = paymentUserService;
        }

        /// <summary>
        /// Получение информации о всех держателей карты 
        /// </summary>
        /// <returns></returns>

        // GET api/<PaymentUserController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _paymentUserService.GetAll());
        }

        /// <summary>
        /// Получение информации о картах пользователя по id 
        /// </summary>
        /// <param name="idPayment">Идентификатор карты</param>
        /// <param name="idUser">Идентификатор пользователя</param>
        /// <returns></returns>

        // GET api/<PaymentUserController>
        [HttpGet("{{idPayment}}/{{idUser}}")]
        public async Task<IActionResult> GetById(int idPayment, int idUser)
        {
            return Ok(await _paymentUserService.GetById(idPayment, idUser));
        }

        /// <summary>
        /// Создание новых карт пользователю
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///       "idPayment": 4,
        ///       "idUser": 10,
        ///       "isActive": true
        ///     }
        ///
        /// </remarks>
        /// <param name="paymentUser">Карты пользователя</param>
        /// <returns></returns>

        // POST api/<PaymentUserController>
        [HttpPost]
        public async Task<IActionResult> Add(PaymentUser paymentUser)
        {
            await _paymentUserService.Create(paymentUser);
            return Ok();
        }

        /// <summary>
        /// Изменение информации о картах пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Todo
        ///     {
        ///       "idPayment": 4,
        ///       "idUser": 10,
        ///       "isActive": false
        ///     }
        ///
        /// </remarks>
        /// <param name="paymentUser">Карты пользователя</param>
        /// <returns></returns>

        // PUT api/<PaymentUserController>
        [HttpPut]
        public async Task<IActionResult> Update(PaymentUser paymentUser)
        {
            await _paymentUserService.Update(paymentUser);
            return Ok();
        }

        /// <summary>
        /// Удаление карты пользователя
        /// </summary>
        /// <param name="idPayment">Идентификатор карты</param>
        /// <param name="idUser">Идентификатор пользователя</param>
        /// <returns></returns>
        // DELETE api/<PaymentUserController>
        [HttpDelete]
        public async Task<IActionResult> Delete(int idPayment, int idUser)
        {
            await _paymentUserService.Delete(idPayment, idUser);
            return Ok();
        }
    }
}
