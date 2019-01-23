using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Persistence.Repositories
{
    public class OtherRepository<TContext> : IOtherRepository<TContext> where TContext : class
    {
        private InvoiceAppDbContext _context;

        public OtherRepository(InvoiceAppDbContext context)
        {
            _context = context;
        }
        public void UpdateById<TEntity>(long Id) where TEntity : class
        {
            var entity = _context.Set<TEntity>().Find(Id);
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<TEntity>().Attach(entity);
        }

        public virtual int Save()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw(e);
            }
        }

    }
}
