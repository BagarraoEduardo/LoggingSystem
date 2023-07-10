using LoggingSystem.Business.Interfaces;
using LoggingSystem.DTO;
using Microsoft.AspNetCore.Mvc;

namespace LoggingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MainController : ControllerBase
    {
        private readonly ILogger<MainController> _logger;
        private readonly IMainService _mainService;

        public MainController(
            ILogger<MainController> logger, 
            IMainService mainService)
        {
            _logger = logger;
            _mainService = mainService;
        }

        [HttpGet("LogInfoExample")]
        public async Task<IActionResult> LogInfoExample()
        {
            var response = new LogInfoResponseDTO()
            {
                Success = false
            };

            try 
            {
                var logInfoResult = await _mainService.LogInfoExample();

                response.Success = logInfoResult.Success;
                response.ErrorMessage = logInfoResult.ErrorMessage;
            }
            catch (Exception exception) 
            {
                _logger.LogError(exception, "An exception has ocurred.");
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

            return Ok(response);
        }
    }
}