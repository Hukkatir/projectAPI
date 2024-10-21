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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _paymentUserService.GetAll());
        }

        [HttpGet("{{idPayment}}/{{idUser}}")]
        public async Task<IActionResult> GetById(int idPayment, int idUser)
        {
            return Ok(await _paymentUserService.GetById(idPayment, idUser));
        }

        [HttpPost]
        public async Task<IActionResult> Add(PaymentUser paymentUser)
        {
            await _paymentUserService.Create(paymentUser);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(PaymentUser paymentUser)
        {
            await _paymentUserService.Update(paymentUser);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int idPayment, int idUser)
        {
            await _paymentUserService.Delete(idPayment, idUser);
            return Ok();
        }
    }
}
