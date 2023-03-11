using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ILineService
    {
        IResult Add(Line line);
        IResult Delete(Line line);
        IResult Update(Line line);
        IDataResult<List<Line>> GetAll();
        IDataResult<Line> GetById(int id);
    }
}
