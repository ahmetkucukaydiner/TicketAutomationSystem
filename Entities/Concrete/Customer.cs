using Core.Entitites.Abstract;

namespace Entities.Concrete
{
    public class Customer : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public int GovId { get; set; }
        public string PassportNumber { get; set; }
        public bool Gender { get; set; }
    }
}
