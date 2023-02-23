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
    public class BusOwnerManager : IBusOwnerService
    {
        private IBusOwnerDal _busOwnerDal;

        public BusOwnerManager(IBusOwnerDal busOwnerDal)
        {
            _busOwnerDal = busOwnerDal;
        }

        [SecuredOperation("busowner.add")]
        [ValidationAspect(typeof(BusOwnerValidator))]
        [CacheRemoveAspect("IBusOwnerService.Get")]
        public IResult Add(BusOwner busOwner)
        {
            _busOwnerDal.Add(busOwner);
            return new SuccessResult(Messages.BusOwnerAdded);
        }

        [SecuredOperation("busowner.delete")]
        [ValidationAspect(typeof(BusOwnerValidator))]
        [CacheRemoveAspect("IBusOwnerService.Get")]
        public IResult Delete(BusOwner busOwner)
        {
            _busOwnerDal.Delete(busOwner);
            return new SuccessResult(Messages.BusOwnerDeleted);
        }

        [SecuredOperation("busowner.getall")]
        [CacheAspect]
        public IDataResult<List<BusOwner>> GetAll()
        {
            return new SuccessDataResult<List<BusOwner>>(_busOwnerDal.GetAll());
        }

        [SecuredOperation("busowner.get")]
        [CacheAspect]
        public IDataResult<BusOwner> GetById(int id)
        {
            return new SuccessDataResult<BusOwner>(_busOwnerDal.Get(b => b.Id == id));
        }


        [SecuredOperation("busowner.update")]
        [ValidationAspect(typeof(BusOwnerValidator))]
        [CacheRemoveAspect("IBusOwnerService.Get")]
        public IResult Update(BusOwner busOwner)
        {
            _busOwnerDal.Update(busOwner);
            return new SuccessResult(Messages.BusOwnerUpdated);
        }
    }
}
