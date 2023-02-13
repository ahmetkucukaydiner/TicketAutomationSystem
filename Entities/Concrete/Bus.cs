using Core.Entitites.Abstract;

namespace Entities.Concrete
{
    public class Bus : IEntity
    {
        public int Id { get; set; }
        public int BusTypeId { get; set; }
        public int BusOwnerId { get; set; }
        public int DriverId { get; set; }
        public int AssistantId { get; set; }
        public string LicensePlate { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
    }
}
