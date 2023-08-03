# LoggingSystem

This is a project that consists in a system that logs everything to database, from simple information to exceptions.

## Technology

This uses Serilog and sinks the logs to SQL Server and Seq. Besides from that I use Automapper to map the entities to DTOs.

## Configuration

To configure this project, you need to:

- Create a ASP Core Web API project;
- Create a Database in SQL Server;
- Download and install Seq Server;
- Add the following NuGets:
    - AutoMapper
    - AutoMapper.Extensions.Microsoft.DependencyInjection
    - Serilog
    - Serilog.AspNetCore
    - Serilog.Extensions.Logging
    - Serilog.Settings.Configuration
    - Serilog.Sinks.MSSqlServer
    - Serilog.Sinks.Seq
- Update the appsettings.json:
    - change the connection string with the database name that you've created;
- Launch the API and you're good to go!

## Author

 Eduardo Bagarrão