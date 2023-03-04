using Core.CrossCuttingConcerns.Logging.Serilog.ConfigurationModels;
using Core.CrossCuttingConcerns.Logging.Serilog.Messages;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System;

namespace Core.CrossCuttingConcerns.Logging.Serilog.Loggers
{
    public class DatabaseLogger : LoggerService
    {
        private IConfiguration _configuration;

        public DatabaseLogger(IConfiguration configuration)
        {
            _configuration = configuration;

            DatabaseLogConfiguration logConfig = configuration
                                                 .GetSection("SerilogConfiguration:DatabaseLogConfiguration")
                                                 .Get<DatabaseLogConfiguration>() ??
                                                 throw new Exception(SerilogMessages.NullOptionsMessages);

            var logDatabaseConnection = string.Format("{0}{1}", logConfig.ConnectionString, logConfig.TableName);


            Logger = new LoggerConfiguration()
                     .WriteTo.MSSqlServer(
                         logDatabaseConnection,
                         sinkOptions: new MSSqlServerSinkOptions { TableName = "Logs", AutoCreateSqlTable = true }
                     )
                     .CreateLogger();
        }

        public DatabaseLogger()
        {

        }
    }
}
