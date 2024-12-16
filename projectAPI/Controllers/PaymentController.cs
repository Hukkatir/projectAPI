using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace projectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private IPaymentService  _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
             _paymentService = paymentService;
        }
        /// <summary>
        /// Получение информации о всех картах
        /// </summary>
        /// <returns></returns>

        // GET api/<PaymentController>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await  _paymentService.GetAll());
        }

        /// <summary>
        /// Получение информации о карте по id
        /// </summary>
        /// <param name="id">Идентификатор карты</param>
        /// <returns></returns>

        // GET api/<PaymentController>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await  _paymentService.GetById(id));
        }

        /// <summary>
        /// Создание новой карты
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///       "paymentId": 5,
        ///       "cardNumber": "2200255555555555",
        ///       "cvv": "871",
        ///       "date": "2024-10-22"
        ///     }
        ///
        /// </remarks>
        /// <param name="payment">Карта</param>
        /// <returns></returns>

        // POST api/<PaymentController>
        [HttpPost]
        public async Task<IActionResult> Add(Payment payment)
        {
            await  _paymentService.Create(payment);
            return Ok();
        }

        /// <summary>
        /// Изменение информации о карте
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Todo
        ///     {
        ///       "idPayment": 5,
        ///       "cardNumber": "2200255555555555",
        ///       "cvv": "871",
        ///       "date": "2027-10-22"
        ///     }
        ///
        /// </remarks>
        /// <param name="payment">Карта</param>
        /// <returns></returns>

        // PUT api/<PaymentController>
        [HttpPut]
        public async Task<IActionResult> Update(Payment payment)
        {
            await  _paymentService.Update(payment);
            return Ok();
        }

        /// <summary>
        /// Удаление карты
        /// </summary>
        /// <param name="id">Идентификатор карты</param>
        /// <returns></returns>

        // DELETE api/<PaymentController>

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await  _paymentService.Delete(id);
            return Ok();
        }
    }
}
