using LoggingSystem.Business.Interfaces;
using LoggingSystem.Models;
using Microsoft.Extensions.Logging;

namespace LoggingSystem.Business
{
    public class MainService : IMainService
    {
        private ILogger<MainService> _logger;

        public MainService(ILogger<MainService> logger)
        {
            _logger = logger;
        }
        
        public async Task<LogMessageResponse> LogExceptionExample()
        {
            var response = new LogMessageResponse()
            {
                Success = false
            };

            try
            {
                throw new Exception("This is an example exception.");

                response.Success = true;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "An error has ocurred.");
                response.ErrorMessage = exception.Message;
            }

            return response;
        }

        public async Task<LogMessageResponse> LogInfoExample()
        {
            var response = new LogMessageResponse() 
            {
                Success = false
            };

            try
            {
                _logger.LogInformation("This is a test information.");

                response.Success = true;
            }
            catch (Exception exception) 
            {
                _logger.LogError(exception, "An error has ocurred.");
                response.ErrorMessage = exception.Message;
            }

            return response;
        }
    }
}
