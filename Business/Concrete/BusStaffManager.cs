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
    public class BusStaffManager : IBusStaffService
    {
        private IBusStaffDal _busStaffDal;

        public BusStaffManager(IBusStaffDal busStaffDal)
        {
            _busStaffDal = busStaffDal;
        }

        public IResult Add(BusStaff busStaff)
        {
            _busStaffDal.Add(busStaff);
            return new SuccessResult(Messages.BusStaffAdded);
        }

        public IResult Delete(BusStaff busStaff)
        {
            _busStaffDal.Delete(busStaff);
            return new SuccessResult(Messages.BusStaffDeleted);
        }

        public IDataResult<List<BusStaff>> GetAll()
        {
            return new SuccessDataResult<List<BusStaff>>(_busStaffDal.GetAll());
        }

        public IDataResult<BusStaff> GetById(int id)
        {
            return new SuccessDataResult<BusStaff>(_busStaffDal.Get(b=>b.Id == id));
        }

        public IResult Update(BusStaff busStaff)
        {
            return new SuccessResult(Messages.BusStaffUpdated);
        }
    }
}
