using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Performance;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class StationManager : IStationService
    {
        private IStationDal _stationDal;

        public StationManager(IStationDal stationDal)
        {
            _stationDal = stationDal;
        }

        //[LogAspect(typeof(DatabaseLogger))]
        [SecuredOperation("station.getall")]
        [CacheAspect]
        [PerformanceAspect(3)]
        public IDataResult<List<Station>> GetAll()
        {
            return new SuccessDataResult<List<Station>>(_stationDal.GetAll());
        }

        [SecuredOperation("station.get")]
        [CacheAspect]
        [PerformanceAspect(3)]
        public IDataResult<Station> GetById(int id)
        {
            return new SuccessDataResult<Station>(_stationDal.Get(x => x.Id == id));
        }

        [SecuredOperation("station.add")]
        [ValidationAspect(typeof(StationValidator))]
        [CacheRemoveAspect("IStationService.Get")]
        public IResult Add(Station station)
        {
            IResult result = BusinessRules.Run(CheckIfStationExists(station.Name));

            if (result != null)
            {
                return result;
            }

            _stationDal.Add(station);
            return new SuccessResult(Messages.StationAdded);
        }

        [SecuredOperation("station.delete")]
        [ValidationAspect(typeof(StationValidator))]
        [CacheRemoveAspect("IStationService.Get")]
        public IResult Delete(Station station)
        {
            _stationDal.Delete(station);
            return new SuccessResult(Messages.StationDeleted);
        }

        [SecuredOperation("station.update")]
        [ValidationAspect(typeof(StationValidator))]
        [CacheRemoveAspect("IStationService.Get")]
        public IResult Update(Station station)
        {
            _stationDal.Update(station);
            return new SuccessResult(Messages.StationUpdated);
        }


        private IResult CheckIfStationExists(string stationName)
        {
            var result = _stationDal.GetAll(s => s.Name == stationName).Any();

            if (result)
            {
                return new ErrorResult(Messages.StationNameAlreadyExists);
            }

            return new SuccessResult();
        }
    }
}
