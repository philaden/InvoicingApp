using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Persistence.Repositories
{
    public interface IOtherRepository<TContext>
    {
        void UpdateById<TEntity>(long Id) where TEntity : class;
        int Save();
    }
}
