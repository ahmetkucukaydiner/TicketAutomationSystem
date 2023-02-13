using Core.Entitites.Abstract;

namespace Entities.Concrete
{
    public class BusSeat : IEntity
    {
        public int Id { get; set; }
        public int BusTypeId { get; set; }
        public int SeatNumber { get; set; }
    }
}
