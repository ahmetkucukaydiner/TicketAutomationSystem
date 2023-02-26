using Business.Abstract;
using Business.Constants.Messages;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class JourneyManager : IJourneyService
    {
        private IJourneyDal _journeyDal;

        public JourneyManager(IJourneyDal journeyDal)
        {
            _journeyDal = journeyDal;
        }

        public IDataResult<List<Journey>> GetAll()
        {
            return new SuccessDataResult<List<Journey>>(_journeyDal.GetAll());
        }

        public IDataResult<Journey> GetById(int id)
        {
            return new SuccessDataResult<Journey>(_journeyDal.Get(j => j.Id == id));
        }

        public IResult Add(Journey journey)
        {
            _journeyDal.Add(journey);
            return new SuccessResult(Messages.JourneyAdded);
        }

        public IResult Update(Journey journey)
        {
            _journeyDal.Update(journey);
            return new SuccessResult(Messages.JourneyUpdated);
        }

        public IResult Delete(Journey journey)
        {
            _journeyDal.Delete(journey);
            return new SuccessResult(Messages.JourneyDeleted);
        }
    }
}
