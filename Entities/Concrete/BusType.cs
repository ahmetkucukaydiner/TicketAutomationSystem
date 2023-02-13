using Core.Entitites.Abstract;

namespace Entities.Concrete
{
    public class BusType : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
