using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class EfPriceDal : EfEntityRepositoryBase<Price, TicketAutomationSystemContext>, IPriceDal
    {
    }
}
