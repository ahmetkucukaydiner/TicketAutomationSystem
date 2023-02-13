using Core.Entitites.Abstract;
using System;

namespace Entities.Concrete
{
    public class LineStation : IEntity
    {
        public int Id { get; set; }
        public int OriginId { get; set; }
        public int LineId { get; set; }
        public int ResponsibleBranchId { get; set; }
        public DateTime DepartureOffSet { get; set; }
    }
}
