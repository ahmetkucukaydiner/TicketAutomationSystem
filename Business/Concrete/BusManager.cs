using Business.Abstract;
using Business.Constants.Messages;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class BusManager : IBusService
    {
        private IBusDal _busDal;

        public BusManager(IBusDal busDal)
        {
            _busDal = busDal;
        }

        public IResult Add(Bus bus)
        {
            _busDal.Add(bus);
            return new SuccessResult(Messages.BusAdded);
        }

        public IResult Delete(Bus bus)
        {
            _busDal.Delete(bus);
            return new SuccessResult(Messages.BusDeleted);
        }

        public IDataResult<List<Bus>> GetAll()
        {
            return new SuccessDataResult<List<Bus>>(_busDal.GetAll());
        }

        public IDataResult<Bus> GetById(int id)
        {
            return new SuccessDataResult<Bus>(_busDal.Get(b => b.Id == id));
        }

        public IResult Update(Bus bus)
        {
            _busDal.Update(bus);
            return new SuccessResult(Messages.BusUpdated);
        }
    }
}
