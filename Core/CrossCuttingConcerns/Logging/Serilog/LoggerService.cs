﻿using Serilog;

namespace Core.CrossCuttingConcerns.Logging.Serilog
{
    public abstract class LoggerService
    {
        protected ILogger Logger;

        public void Verbose(string message) => Logger.Verbose(message);
        public void Error(string message) => Logger.Error(message);
        public void Info(string message) => Logger.Information(message);
        public void Fatal(string message) => Logger.Fatal(message);
        public void Warn(string message) => Logger.Warning(message);
        public void Debug(string message) => Logger.Debug(message);
    }
}
