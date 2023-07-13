using Serilog.Events;
using Serilog;

namespace LoggingSystem.Extension
{
    public static class LoggingSetup
    {
        public static IHostBuilder ConfigureLogging(this WebApplicationBuilder builder)
        {
            return builder.Host.UseSerilog(new LoggerConfiguration()
                   //.WriteTo.Seq("http://localhost:5341")
                   .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                   .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                   .MinimumLevel.Override("Microsoft.EntityFrameworkCore.Database.Command", LogEventLevel.Warning)
                   .ReadFrom.Configuration(builder.Configuration)
                   .CreateLogger());
        }
    }
}
