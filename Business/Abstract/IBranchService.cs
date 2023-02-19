using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBranchService
    {
        IDataResult<List<Branch>> GetAll();
        IDataResult<Branch> GetById(int id);
        IResult Add(Branch branch);
        IResult Delete(Branch branch);
        IResult Update(Branch branch);
    }
}
