using System;
using System.Collections.Generic;
using System.Text;

namespace agap2it.projects.labs.SWT.DataAccess.DataAccessModels
{
    public class BusStationsDataAccessModel
    {
        public string BusNumber { get; set; }
        public IEnumerable<string> Stations { get; set; }
    }
}
