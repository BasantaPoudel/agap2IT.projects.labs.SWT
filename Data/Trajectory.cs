using agap2it.projects.labs.SWT.Data.Interfaces;
using System;
using System.Collections.Generic;

#nullable disable

namespace agap2it.projects.labs.SWT.Data
{
    public partial class Trajectory : IEntity
    {
        public Trajectory()
        {
            TrajectoryStations = new HashSet<TrajectoryStation>();
        }

        public long Id { get; set; }
        public Guid Uuid { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public TimeSpan EstimatedTotalTime { get; set; }

        public virtual ICollection<TrajectoryStation> TrajectoryStations { get; set; }
    }
}
