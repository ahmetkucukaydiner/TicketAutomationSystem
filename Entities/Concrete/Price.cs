using Core.Entitites.Abstract;

namespace Entities.Concrete
{
    public class Price : IEntity
    {
        public int Id { get; set; }
        public int OriginId { get; set; }
        public int DestinationId { get; set; }
        public decimal OfflinePrice { get; set; }
        public decimal OnlinePrice { get; set; }
        public bool IsActive { get; set; }
    }
}
