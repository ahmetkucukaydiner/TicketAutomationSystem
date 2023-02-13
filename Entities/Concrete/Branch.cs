using Core.Entitites.Abstract;

namespace Entities.Concrete
{
    public class Branch : IEntity
    {
        public int Id { get; set; }
        public int StationId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string TaxOffice { get; set; }
        public string TaxNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
