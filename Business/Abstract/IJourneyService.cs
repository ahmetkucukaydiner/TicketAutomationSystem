using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IJourneyService
    {
        IDataResult<List<Journey>> GetAll();
        IDataResult<Journey> GetById(int id);
        IResult Add(Journey journey);
        IResult Update(Journey journey);
        IResult Delete(Journey journey);
    }
}
