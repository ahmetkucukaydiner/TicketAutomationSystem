using Core.Entitites.Abstract;

namespace Entities.Concrete
{
    public class BusOwner : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string TaxOffice { get; set; }
        public string TaxNumber { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
    }
}
