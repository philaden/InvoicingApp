using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvocingApp.Data.Domains
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public BaseEntity()
        {
            Created = DateTime.Now;
            IsActive = true;
            IsDeleted = false;
        }
    }
}
