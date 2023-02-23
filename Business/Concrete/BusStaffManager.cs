using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
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

        [SecuredOperation("busstaff.add")]
        [ValidationAspect(typeof(BusStaffValidator))]
        [CacheRemoveAspect("IBusStaffService.Get")]
        public IResult Add(BusStaff busStaff)
        {
            _busStaffDal.Add(busStaff);
            return new SuccessResult(Messages.BusStaffAdded);
        }

        [SecuredOperation("busstaff.delete")]
        [ValidationAspect(typeof(BusStaffValidator))]
        [CacheRemoveAspect("IBusStaffService.Get")]
        public IResult Delete(BusStaff busStaff)
        {
            _busStaffDal.Delete(busStaff);
            return new SuccessResult(Messages.BusStaffDeleted);
        }

        [SecuredOperation("busstaff.getall")]
        [CacheAspect]
        public IDataResult<List<BusStaff>> GetAll()
        {
            return new SuccessDataResult<List<BusStaff>>(_busStaffDal.GetAll());
        }

        [SecuredOperation("busstaff.get")]
        [CacheAspect]
        public IDataResult<BusStaff> GetById(int id)
        {
            return new SuccessDataResult<BusStaff>(_busStaffDal.Get(b=>b.Id == id));
        }

        [SecuredOperation("busstaff.update")]
        [ValidationAspect(typeof(BusStaffValidator))]
        [CacheRemoveAspect("IBusStaffService.Get")]
        public IResult Update(BusStaff busStaff)
        {
            return new SuccessResult(Messages.BusStaffUpdated);
        }
    }
}
