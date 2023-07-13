using LoggingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingSystem.Business.Interfaces
{
    public interface IMainService
    {
        Task<LogMessageResponse> LogInfoExample();
        Task<LogMessageResponse> LogExceptionExample();
    }
}
