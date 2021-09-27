using agap2it.projects.labs.SWT.Data;
using agap2it.projects.labs.SWT.DataAccess.DataAccessModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace agap2it.projects.labs.SWT.DataAccess.Interfaces
{
    public interface IBusDataAccessObject : IBaseDataAccessObject<Bu>
    {
        Task<IEnumerable<BusStationsDataAccessModel>> GetBusWithStations();
    }
}
