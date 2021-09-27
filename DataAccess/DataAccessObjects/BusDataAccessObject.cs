using agap2it.projects.labs.SWT.Data;
using agap2it.projects.labs.SWT.DataAccess.DataAccessModels;
using agap2it.projects.labs.SWT.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace agap2it.projects.labs.SWT.DataAccess.DataAccessObjects
{
    public class BusDataAccessObject : IBusDataAccessObject, IBaseDataAccessObject<Bu>
    {
        private readonly ServiceWaitingTimeContext _context;

        public async Task<IEnumerable<BusStationsDataAccessModel>> GetBusWithStations()
        {
            var result = await _context.buses.Include(c => c.Stations).Select(c => new BusStationsDataAccessModel() { BusNumber = c.}
        }
    }
}
