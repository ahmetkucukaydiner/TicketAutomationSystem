using Core.Entitites.Abstract;

namespace Core.Entitites.Concrete
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public int BranchId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool IsActive { get; set; }
    }
}
