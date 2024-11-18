using BackpackerOfLife.Blog.API.AppServices.IAppServices;
using BackpackerOfLife.Blog.API.Model;
using BackpackerOfLife.Blog.API.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace BackpackerOfLife.Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : Controller
    {
        private readonly IMainAppService _mainAppService;
        public MainController(IMainAppService mainAppService)
        {
            _mainAppService = mainAppService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Content>>> Get(CancellationToken cancellationToken)
        {
            var result = await _mainAppService.Get(cancellationToken);
            return Ok(result);
        }

        [HttpGet("GetById/{id:int}", Name = "GetById")]
        public async Task<ActionResult<Content>> GetById(int id, CancellationToken cancellationToken)
        {
            var result = await _mainAppService.GetById(id, cancellationToken);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("GetByTitle")]
        public async Task<ActionResult<IEnumerable<Content>>> GetByTitle(string title, CancellationToken cancellationToken)
        {
            var result = await _mainAppService.GetByTitle(title, cancellationToken);
            if(!result.Any())
                return NotFound();

            return Ok(result);
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create(Content content, CancellationToken cancellationToken)
        {
            await _mainAppService.Create(content, cancellationToken);

            return CreatedAtRoute(nameof(GetById), new { Id = content.Id}, content);
        }

        [HttpPut("Update/{id:int}")]
        public async Task<ActionResult> Update(int id, [FromBody] Content content, CancellationToken cancellationToken)
        {
            await _mainAppService.Update(id, content, cancellationToken);

            return Ok();
        }

        [HttpDelete("Delete/{id:int}")]
        public async Task<ActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var result = await _mainAppService.GetById(id, cancellationToken);
            if (result == null)
                return NotFound();

            await _mainAppService.Delete(result, cancellationToken);
            return Ok();
        }
    }
}
