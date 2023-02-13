using Core.Entitites.Abstract;

namespace Entities.Concrete
{
    public class BusStaff : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string EmploymentType { get; set; }
        public bool Gender { get; set; }
        public string GovId { get; set; }
        public bool IsActive { get; set; }
        public string PassportNumber { get; set; }
    }
}
