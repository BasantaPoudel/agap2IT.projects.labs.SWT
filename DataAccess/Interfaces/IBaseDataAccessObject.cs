using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace agap2it.projects.labs.SWT.DataAccess.Interfaces
{
    public interface IBaseDataAccessObject<T>
    {
        public Task<IEnumerable<T>> List();
        public Task Insert(T record);
        public Task<T> Get(long id);
        public Task Update(T record);
        public Task Remove(T record);
    }
}
