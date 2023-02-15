using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfStationDal : EfEntityRepositoryBase<Station, TicketAutomationSystemContext>, IStationDal
    {
    }
}
