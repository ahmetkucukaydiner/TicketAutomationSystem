using Core.CrossCuttingConcerns.Logging.Serilog.ConfigurationModels;
using Core.CrossCuttingConcerns.Logging.Serilog.Messages;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.Generic;
using System.Data;

namespace Core.CrossCuttingConcerns.Logging.Serilog.Loggers
{
    public class DatabaseLogger : LoggerService
    {
        private IConfiguration _configuration;

        public DatabaseLogger()
        {

        }
        public DatabaseLogger(IConfiguration configuration)
        {
            _configuration = configuration;

            DatabaseLogConfiguration logConfig = configuration
                                                 .GetSection("Serilog:DatabaseLogConfiguration")
                                                 .Get<DatabaseLogConfiguration>() ??
                                                 throw new Exception(SerilogMessages.NullOptionsMessages);

            var logDatabaseConnection = string.Format("{0}", logConfig.ConnectionString);

            Logger = new LoggerConfiguration()
                     .WriteTo.MSSqlServer(
                         logDatabaseConnection,
                         sinkOptions: new MSSqlServerSinkOptions { TableName = $"{logConfig.TableName}", AutoCreateSqlTable = true },
                         restrictedToMinimumLevel: LogEventLevel.Information,
                         columnOptions: GetColumnOptions()
                     )
                     .CreateLogger();
        }



        public static ColumnOptions GetColumnOptions()
        {
            var columnOptions = new ColumnOptions();

            columnOptions.Id.ColumnName = "Id";


            columnOptions.Store.Remove(StandardColumn.TimeStamp);
            columnOptions.Store.Remove(StandardColumn.Message);
            columnOptions.Store.Remove(StandardColumn.Level);
            columnOptions.Store.Remove(StandardColumn.Exception);
            columnOptions.Store.Remove(StandardColumn.MessageTemplate);
            columnOptions.Store.Remove(StandardColumn.Properties);


            columnOptions.AdditionalColumns = new List<SqlColumn>
            {
                new SqlColumn
                    { DataType = SqlDbType.VarChar, ColumnName = "Message", DataLength = 250, AllowNull = false },
                new SqlColumn
                    { DataType = SqlDbType.VarChar, ColumnName = "CreatedBy", DataLength = 50, AllowNull = false },
                new SqlColumn
                    { DataType = SqlDbType.DateTime2, ColumnName = "CreatedDate", DataLength = 7, AllowNull = false },
            };

            return columnOptions;

        }
    }
}
