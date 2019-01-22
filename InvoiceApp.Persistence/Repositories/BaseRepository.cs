using InvoiceApp.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;

namespace InvoiceApp.Persistence.Repositories
{
    public class BaseRepository<TContext> : IBaseRepository<TContext> where TContext : DbContext
    {
        private InvoiceAppDbContext _context;

        public BaseRepository(InvoiceAppDbContext context)
        {
            _context = context;
        }

        public void Create<TEntity>(TEntity entity) where TEntity : class
        {
            if (entity == null) return;
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public void Create<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            if (entities == null) return;
            foreach (var entity in entities)
            {
                _context.Set<TEntity>().Add(entity);
                _context.SaveChanges();
            }
        }

        public void Delete<TEntity>(long Id) where TEntity : class
        {
            if (Id == 0 || Id < 0) return;
            var entity = _context.Set<TEntity>().Find(Id);
            if (entity == null) return;
            var dbSet = _context.Set<TEntity>();
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public void Delete<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            if (entities == null) return;
            foreach (var entity in entities)
            {
                _context.Set<TEntity>().Remove(entity);
                _context.SaveChanges();
            }

        }

        public IEnumerable<TEntity> Getall<TEntity>() where TEntity : class
        {
            {
                return _context.Set<TEntity>().AsQueryable();
            }

        }

        public TEntity GetById<TEntity>(long Id) where TEntity : class
        {
            var entity = _context.Set<TEntity>().Find(Id);
            return entity;

        }

        public IEnumerable<TEntity> GetMany<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = default(int?), int? take = default(int?)) where TEntity : class
        {
            includeProperties = includeProperties ?? string.Empty;
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }
            return query;

        }

        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            if (entity == null) return;
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<TEntity>().Attach(entity);
        }
    }
}
