using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBusService
    {
        IDataResult<List<Bus>> GetAll();
        IDataResult<Bus> GetById(int id);
        IResult Add(Bus bus);
        IResult Delete(Bus bus);
        IResult Update(Bus bus);
    }
}
