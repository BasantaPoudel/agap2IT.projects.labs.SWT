using agap2it.projects.labs.SWT.Data;
using agap2it.projects.labs.SWT.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace agap2it.projects.labs.SWT.DataAccess.DataAccessObjects
{
    class GenericDataAccessObject
    {
        private readonly ServiceWaitingTimeContext _context;

        public GenericDataAccessObject(ServiceWaitingTimeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> List<T>() where T : class
        {
            var result = await _context.Set<T>().ToListAsync();
            return result;
        }

        public async Task Insert<T>(T record) where T : class
        {
            if (record is IEntity entity)
            {
                entity.CreatedAt = System.DateTime.UtcNow;
                entity.UpdatedAt = System.DateTime.UtcNow;
                entity.Uuid = System.Guid.NewGuid();
                await _context.AddAsync(entity);
            }
            else
            {
                await _context.Set<T>().AddAsync(record);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<T> Get<T>(long id) where T : class
        {
            var record = await _context.Set<T>().FindAsync(id);
            return record;
        }

        public async Task Update<T>(T record) where T : class
        {
            _context.Set<T>().Update(record);
            await _context.SaveChangesAsync();
        }

        public async Task Delete<T>(T record) where T : class
        {
            if (record is IEntity entity)
            {
                entity.IsDeleted = true;
                _context.Entry(record).State = EntityState.Modified;
            }
            else
            {
                _context.Set<T>().Remove(record);
            }
            await _context.SaveChangesAsync();
        }

    }

}
}
