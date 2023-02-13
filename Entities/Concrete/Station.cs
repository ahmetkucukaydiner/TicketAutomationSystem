using Core.Entitites.Abstract;

namespace Entities.Concrete
{
    public class Station : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string City { get; set; }
    }
}
