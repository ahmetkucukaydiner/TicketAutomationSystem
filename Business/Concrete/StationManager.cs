using Business.Abstract;
using Business.Constants.Messages;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class StationManager : IStationService
    {
        private IStationDal _stationDal;
        public IDataResult<List<Station>> GetAll()
        {
            return new SuccessDataResult<List<Station>>(_stationDal.GetAll());
        }

        public IDataResult<Station> GetById(int id)
        {
            return new SuccessDataResult<Station>(_stationDal.Get(x => x.Id == id));
        }

        public IResult Add(Station station)
        {
            _stationDal.Add(station);
            return new SuccessResult(Messages.StationAdded);
        }

        public IResult Delete(Station station)
        {
            _stationDal.Delete(station);
            return new SuccessResult(Messages.StationDeleted);
        }

        public IResult Update(Station station)
        {
            _stationDal.Update(station);
            return new SuccessResult(Messages.StationUpdated);
        }
    }
}
