using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class BusManager : IBusService
    {
        private IBusDal _busDal;

        public BusManager(IBusDal busDal)
        {
            _busDal = busDal;
        }

        [LogAspect(typeof(DatabaseLogger))]
        [SecuredOperation("bus.add")]
        [ValidationAspect(typeof(BusValidator))]
        [CacheRemoveAspect("IBusService.Get")]
        public IResult Add(Bus bus)
        {
            _busDal.Add(bus);
            return new SuccessResult(Messages.BusAdded);
        }

        [SecuredOperation("bus.delete")]
        [ValidationAspect(typeof(BusValidator))]
        [CacheRemoveAspect("IBusService.Get")]
        public IResult Delete(Bus bus)
        {
            _busDal.Delete(bus);
            return new SuccessResult(Messages.BusDeleted);
        }

        [SecuredOperation("bus.getall")]
        [CacheAspect]
        public IDataResult<List<Bus>> GetAll()
        {
            return new SuccessDataResult<List<Bus>>(_busDal.GetAll());
        }

        [SecuredOperation("bus.get")]
        [CacheAspect]
        public IDataResult<Bus> GetById(int id)
        {
            return new SuccessDataResult<Bus>(_busDal.Get(b => b.Id == id));
        }

        [SecuredOperation("bus.update")]
        [ValidationAspect(typeof(BusValidator))]
        [CacheRemoveAspect("IBusService.Get")]
        public IResult Update(Bus bus)
        {
            _busDal.Update(bus);
            return new SuccessResult(Messages.BusUpdated);
        }
    }
}
