using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IPriceService
    {
        IDataResult<List<Price>> GetAll();
        IDataResult<Price> GetById(int id);
        IResult Add(Price price);
        IResult Delete(Price price);
        IResult Update(Price price);
    }
}
