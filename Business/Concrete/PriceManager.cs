using Business.Abstract;
using Business.Constants.Messages;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class PriceManager : IPriceService
    {
        private IPriceDal _priceDal;

        public PriceManager(IPriceDal priceDal)
        {
            _priceDal = priceDal;
        }

        public IDataResult<List<Price>> GetAll()
        {
            return new SuccessDataResult<List<Price>>(_priceDal.GetAll());
        }

        public IDataResult<Price> GetById(int id)
        {
            return new SuccessDataResult<Price>(_priceDal.Get(p => p.Id == id));
        }

        public IResult Add(Price price)
        {
            _priceDal.Add(price);
            return new SuccessResult(Messages.PriceAdded);
        }

        public IResult Delete(Price price)
        {
            _priceDal.Delete(price);
            return new SuccessResult(Messages.PriceDeleted);
        }

        public IResult Update(Price price)
        {
            _priceDal.Update(price);
            return new SuccessResult(Messages.PriceUpdated);
        }
    }
}
