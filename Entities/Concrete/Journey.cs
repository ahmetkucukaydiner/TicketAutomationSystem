﻿using Core.Entitites.Abstract;
using System;

namespace Entities.Concrete
{
    public class Journey : IEntity
    {
        public int Id { get; set; }
        public int LineId { get; set; }
        public int BusId { get; set; }
        public int BusTypeId { get; set; }
        public int DriverId { get; set; }
        public int AssistantId { get; set; }
        public int OriginId { get; set; }
        public int DestinationId { get; set; }
        public string LineCode { get; set; }
        public DateTime Duration { get; set; }
        public DateTime DepartureTime { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
