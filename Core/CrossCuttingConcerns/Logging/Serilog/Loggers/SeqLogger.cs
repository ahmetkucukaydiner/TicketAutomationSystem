using Core.CrossCuttingConcerns.Logging.Serilog.ConfigurationModels;
using Core.CrossCuttingConcerns.Logging.Serilog.Messages;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using System;

namespace Core.CrossCuttingConcerns.Logging.Serilog.Loggers
{
    public class SeqLogger : LoggerService
    {
        private IConfiguration _configuration;

        public SeqLogger(IConfiguration configuration)
        {
            _configuration = configuration;

            SeqConfiguration seqConfig = configuration.GetSection("Serilog:Seq")
                                                      .Get<SeqConfiguration>() ??
                                         throw new Exception(SerilogMessages.NullOptionsMessages);


            var seqConnection = string.Format("{0}", seqConfig.ServerUrl);

            Logger = new LoggerConfiguration()
                     .WriteTo.Seq(
                         seqConnection,
                         restrictedToMinimumLevel: LogEventLevel.Information
                     )
                     .CreateLogger();
        }

        public SeqLogger()
        {

        }



    }
}
