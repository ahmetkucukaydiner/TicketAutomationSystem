using Core.Entitites.Abstract;

namespace Entities.Concrete
{
    public class Pnr : IEntity
    {
        public int Id { get; set; }
        public bool IsUsed { get; set; }
    }
}
