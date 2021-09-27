using System;
using System.Collections.Generic;
using System.Text;

namespace agap2it.projects.labs.SWT.Data.Interfaces
{
    public interface IEntity
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public bool IsDeleted { get; set; }
        public Guid Uuid { get; set; }
    }
}
