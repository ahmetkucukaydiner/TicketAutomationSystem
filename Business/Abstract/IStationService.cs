using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IStationService
    {
        IDataResult<List<Station>> GetAll();
        IDataResult<Station> GetById(int id);
        IResult Add(Station station);
        IResult Delete(Station station);
        IResult Update(Station station);
    }
}
