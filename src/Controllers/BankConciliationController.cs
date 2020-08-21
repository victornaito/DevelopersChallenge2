using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nibo.InfraEstructure.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nibo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankConciliationController : ControllerBase
    {
        private readonly ILogger<BankConciliationController> _logger;
        private readonly ConciliationService _conciliationService;

        public BankConciliationController(ILogger<BankConciliationController> logger, ConciliationService conciliationService)
        {
            _logger = logger;
            _conciliationService = conciliationService;
        }


        [HttpPost]
        public async Task<IActionResult> AddFiles(List<IFormFile> files)
        {
            var result = await _conciliationService.Process(files);

            if (result == null)
                return await Task.FromResult(new BadRequestObjectResult("Inclua Arquivos no formato OFX para processamento!"));

            return await Task.FromResult(new OkObjectResult(result));
        }
    }
}
