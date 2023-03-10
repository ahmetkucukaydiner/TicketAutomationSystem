using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog;
using Core.Utilities.Interceptors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Core.Aspect.Autofac.Logging
{
    public class LogAspect : MethodInterception
    {
        private LoggerService _loggerService;

        public LogAspect(Type loggerService)
        {
            if (loggerService.BaseType != typeof(LoggerService))
            {
                throw new Exception("Bu bir log sınıfı değil");
            }

            _loggerService = (LoggerService)Activator.CreateInstance(loggerService);
        }

        protected override void OnBefore(IInvocation invocation)
        {
            _loggerService.Info(GetLogDetail(invocation).ToString());
        }

        private LogDetailWithException GetLogDetail(IInvocation invocation)
        {
            var logParameters = new List<LogParameter>();

            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                logParameters.Add(new LogParameter
                {
                    Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                    Value = invocation.Arguments[i],
                    Type = invocation.Arguments[i].GetType().Name
                });
            }

            var logDetail = new LogDetailWithException
            {
                MethodName = invocation.Method.Name,
                LogParameters = logParameters
            };

            _loggerService.Info(JsonConvert.SerializeObject(logDetail));

            return logDetail;
        }
    }
}
