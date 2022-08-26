using Domain.DTO;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {

        private readonly IProcessFile _processFile;
        private readonly IReadFile _readFile;

        public FileController(IProcessFile processFile, IReadFile readFile)
        {
            _processFile = processFile;
            _readFile = readFile;
        }

        [HttpPost()]
        public async Task<IActionResult> ProcessFile([FromBody] string path, CancellationToken cancellationToken) {
            await _processFile.Execute(path, cancellationToken);
            return NoContent();
        }

    }
}
