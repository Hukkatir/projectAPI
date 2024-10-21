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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _myRatingService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _myRatingService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(MyRating myRating)
        {
            await _myRatingService.Create(myRating);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(MyRating myRating)
        {
            await _myRatingService.Update(myRating);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _myRatingService.Delete(id);
            return Ok();
        }
    }
}
