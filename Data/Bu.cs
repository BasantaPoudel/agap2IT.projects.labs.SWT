using agap2it.projects.labs.SWT.Data.Interfaces;
using System;
using System.Collections.Generic;

#nullable disable

namespace agap2it.projects.labs.SWT.Data
{
    public partial class Bu : IEntity
    {
        public Bu()
        {
            BusStations = new HashSet<BusStation>();
        }

        public long Id { get; set; }
        public Guid Uuid { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public bool IsDeleted { get; set; }
        public int BusNumber { get; set; }
        public int Capacity { get; set; }

        public virtual ICollection<BusStation> BusStations { get; set; }
    }
}
