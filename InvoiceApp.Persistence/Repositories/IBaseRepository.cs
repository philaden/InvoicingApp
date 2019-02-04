using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Persistence.Repository
{
    public interface IBaseRepository<TContext>
    {
        IEnumerable<TEntity> Getall<TEntity>() where TEntity : class;
        TEntity GetById<TEntity>(long Id) where TEntity : class;
        IEnumerable<TEntity> GetMany<TEntity>(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null) where TEntity : class;

        object Create<TEntity>(TEntity entity) where TEntity : class;
        void Create<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        void Delete<TEntity>(long Id) where TEntity : class;
        void Delete<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        void Update<TEntity>(TEntity entity) where TEntity : class;
    }
}
