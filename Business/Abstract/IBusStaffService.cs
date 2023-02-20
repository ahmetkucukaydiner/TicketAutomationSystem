using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBusStaffService
    {
        IDataResult<List<BusStaff>> GetAll();
        IDataResult<BusStaff> GetById(int id);
        IResult Add(BusStaff busStaff);
        IResult Delete(BusStaff busStaff);
        IResult Update(BusStaff busStaff);
    }
}
