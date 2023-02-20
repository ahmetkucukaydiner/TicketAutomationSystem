using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBusOwnerService
    {
        IDataResult<List<BusOwner>> GetAll();
        IDataResult<BusOwner> GetById(int id);
        IResult Add(BusOwner busOwner);
        IResult Delete(BusOwner busOwner);
        IResult Update(BusOwner busOwner);
    }
}
