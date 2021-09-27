using agap2it.projects.labs.SWT.Data.Interfaces;
using System;
using System.Collections.Generic;

#nullable disable

namespace agap2it.projects.labs.SWT.Data
{
    public partial class Station : IEntity
    {
        public long Id { get; set; }
        public Guid Uuid { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public long NextStationId { get; set; }
        public string Location { get; set; }
        public TimeSpan TimeToNextStation { get; set; }
        public DateTime Checkin { get; set; }

        public virtual BusStation BusStation { get; set; }
        public virtual TrajectoryStation TrajectoryStation { get; set; }
    }
}
