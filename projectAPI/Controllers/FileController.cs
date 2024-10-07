using Domian.Interfaces;
using Domian.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using File = Domian.Models.File;

namespace projectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private IFileService _fileService;
        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _fileService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _fileService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(File f)
        {
            await _fileService.Create(f);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(File f)
        {
            await _fileService.Update(f);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _fileService.Delete(id);
            return Ok();
        }
    }
}


