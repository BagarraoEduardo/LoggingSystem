using Serilog.Events;
using Serilog;

namespace LoggingSystem.Extension
{
    public static class LoggingSetup
    {
        public static IHostBuilder ConfigureLogging(this WebApplicationBuilder builder)
        {
            Serilog.Debugging.SelfLog.Enable(msg => Console.WriteLine(msg));
            
            return builder.Host.UseSerilog(new LoggerConfiguration()
                   .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                   .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                   .MinimumLevel.Override("Microsoft.EntityFrameworkCore.Database.Command", LogEventLevel.Warning)
                   .ReadFrom.Configuration(builder.Configuration)
                   .CreateLogger());
            
        }
    }
}
