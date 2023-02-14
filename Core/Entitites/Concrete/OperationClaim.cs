using Core.Entitites.Abstract;

namespace Core.Entitites.Concrete
{
    public class OperationClaim : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
