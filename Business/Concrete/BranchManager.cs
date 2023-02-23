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
    public class BranchManager : IBranchService
    {
        private IBranchDal _branchDal;

        public BranchManager(IBranchDal branchDal)
        {
            _branchDal = branchDal;
        }

        [SecuredOperation("branch.add")]
        [ValidationAspect(typeof(BranchValidator))]
        [CacheRemoveAspect("IBranchService.Get")]
        public IResult Add(Branch branch)
        {
            _branchDal.Add(branch);
            return new SuccessResult(Messages.BranchAdded);
        }

        [SecuredOperation("branch.delete")]
        [ValidationAspect(typeof(BranchValidator))]
        [CacheRemoveAspect("IBranchService.Get")]
        public IResult Delete(Branch branch)
        {
            _branchDal.Delete(branch);
            return new SuccessResult(Messages.BranchDeleted);
        }

        [SecuredOperation("branch.getall")]
        [CacheAspect]
        public IDataResult<List<Branch>> GetAll()
        {
            return new SuccessDataResult<List<Branch>>(_branchDal.GetAll());
        }

        [SecuredOperation("branch.get")]
        [CacheAspect]
        public IDataResult<Branch> GetById(int id)
        {
            return new SuccessDataResult<Branch>(_branchDal.Get(b=>b.Id == id));
        }

        [SecuredOperation("branch.update")]
        [ValidationAspect(typeof(BranchValidator))]
        [CacheRemoveAspect("IBranchService.Get")]
        public IResult Update(Branch branch)
        {
            _branchDal.Update(branch);
            return new SuccessResult(Messages.BranchUpdated);
        }
    }
}