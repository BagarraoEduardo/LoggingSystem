using AutoMapper;
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
        private readonly IMapper _mapper;

        public MainController(
            ILogger<MainController> logger,
            IMainService mainService,
            IMapper mapper)
        {
            _logger = logger;
            _mainService = mainService;
            _mapper = mapper;
        }

        [HttpGet("LogInfoExample")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(LogMessageResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(LogMessageResponseDTO), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> LogInfoExample()
        {
            var response = new LogMessageResponseDTO()
            {
                Success = false
            };

            try
            {
                response = _mapper.Map<LogMessageResponseDTO>(await _mainService.LogInfoExample());
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "An exception has ocurred.");
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

            return Ok(response);
        }



        [HttpGet("LogExceptionExample")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(LogMessageResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(LogMessageResponseDTO), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> LogExceptionExample()
        {
            var response = new LogMessageResponseDTO()
            {
                Success = false
            };

            try
            {
                response = _mapper.Map<LogMessageResponseDTO>(await _mainService.LogExceptionExample());
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