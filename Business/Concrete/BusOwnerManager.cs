using Business.Abstract;
using Business.Constants.Messages;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BusOwnerManager : IBusOwnerService
    {
        private IBusOwnerDal _busOwnerDal;

        public BusOwnerManager(IBusOwnerDal busOwnerDal)
        {
            _busOwnerDal = busOwnerDal;
        }

        public IResult Add(BusOwner busOwner)
        {
            _busOwnerDal.Add(busOwner);
            return new SuccessResult(Messages.BusOwnerAdded);
        }

        public IResult Delete(BusOwner busOwner)
        {
            _busOwnerDal.Delete(busOwner);
            return new SuccessResult(Messages.BusOwnerDeleted);
        }

        public IDataResult<List<BusOwner>> GetAll()
        {
            return new SuccessDataResult<List<BusOwner>>(_busOwnerDal.GetAll());
        }

        public IDataResult<BusOwner> GetById(int id)
        {
            return new SuccessDataResult<BusOwner>(_busOwnerDal.Get(b => b.Id == id));
        }

        public IResult Update(BusOwner busOwner)
        {
            _busOwnerDal.Update(busOwner);
            return new SuccessResult(Messages.BusOwnerUpdated);
        }
    }
}
