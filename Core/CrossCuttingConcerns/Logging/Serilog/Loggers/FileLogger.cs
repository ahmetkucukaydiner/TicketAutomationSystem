using Core.CrossCuttingConcerns.Logging.Serilog.ConfigurationModels;
using Core.CrossCuttingConcerns.Logging.Serilog.Messages;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.IO;

namespace Core.CrossCuttingConcerns.Logging.Serilog.Loggers
{
    public class FileLogger : LoggerService
    {
        private IConfiguration _configuration;

        public FileLogger(IConfiguration configuration)
        {
            _configuration = configuration;

            FileLogConfiguration logConfig = configuration.GetSection("Serilog:File")
                                                          .Get<FileLogConfiguration>() ??
                                             throw new Exception(SerilogMessages.NullOptionsMessages);

            string logFilePath =
                string.Format("{0}{1}", Directory.GetCurrentDirectory() + logConfig.FolderPath, ".txt");

            Logger = new LoggerConfiguration()
                     .WriteTo.File(
                          logFilePath,
                          rollingInterval: RollingInterval.Day,
                          retainedFileCountLimit: null,
                          fileSizeLimitBytes: 5000000,
                          outputTemplate:
                          "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz [{Level}] {Message}{NewLine}{Exception}")
                      .CreateLogger();
        }
    }
}
