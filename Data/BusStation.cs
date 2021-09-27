using System;
using System.Collections.Generic;

#nullable disable

namespace agap2it.projects.labs.SWT.Data
{
    public partial class BusStation
    {
        public long BusId { get; set; }
        public long StationId { get; set; }

        public virtual Bu Bus { get; set; }
        public virtual Station Station { get; set; }
    }
}
