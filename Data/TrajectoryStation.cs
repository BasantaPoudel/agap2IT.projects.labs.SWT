using System;
using System.Collections.Generic;

#nullable disable

namespace agap2it.projects.labs.SWT.Data
{
    public partial class TrajectoryStation
    {
        public long TrajectoryId { get; set; }
        public long StationId { get; set; }

        public virtual Trajectory Trajectory { get; set; }
        public virtual Station Station { get; set; }
    }
}
