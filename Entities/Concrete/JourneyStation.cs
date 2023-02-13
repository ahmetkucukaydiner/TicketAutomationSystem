using Core.Entitites.Abstract;
using System;

namespace Entities.Concrete
{
    public class JourneyStation : IEntity
    {
        public int Id { get; set; }
        public int JourneyId { get; set; }
        public int StationId { get; set; }
        public DateTime DepartureTime { get; set; }
        public bool IsActive { get; set; }
    }
}
