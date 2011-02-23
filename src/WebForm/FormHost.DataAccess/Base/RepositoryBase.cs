using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Data.Objects;
using System.Data.Entity;
using FormHost.Model.Base;

namespace FormHost.DataAccess.Base
{
    public abstract class RepositoryBase<T, TColl, DC>
        where T : class, IDomainEntity, new()
        where TColl: DomainEntityContainer<T>, new()
        where DC : BaseDataContext
    {
        public DC DataContext { get; private set; }
        public DbContext DB { get; set; }

        public RepositoryBase(DC dc)
        {
            this.DataContext = dc;
            this.DB = dc.DB;
        }


        public virtual T Get(int id)
        {
            return DB.Set<T>().Find(id);
        }

        public virtual T Get(int id, params string[] selectors)
        {
            var de = new TColl();
            var query = DB.Set<T>().AsQueryable();
            selectors.ToList().ForEach(sel => query = query.Include(sel));
            query = (System.Data.Entity.Infrastructure.DbQuery<T>)query.Where(ent => ent.Id == id);

            return query.ToList().First(); // sima Single lenne hivatalosan, de ez gyorsabb
        }

        public virtual T GetWithLoad(int id, params string[] selectors)
        {
            var entity = Get(id);
            selectors.ToList().ForEach(s => DataContext.OC.LoadProperty(entity, s));
            return entity;
        }

        public virtual T Get(Expression<Func<T, bool>> whereCondition, params string[] selectors)
        {
            var de = new TColl();
            var query = DB.Set<T>().AsQueryable();
            selectors.ToList().ForEach(sel => query = query.Include(sel));
            query = (System.Data.Entity.Infrastructure.DbQuery<T>)query.Where(whereCondition);

            return query.ToList().First(); // sima Single lenne hivatalosan, de ez gyorsabb
        }

        public virtual T GetWithLoad(Expression<Func<T, bool>> whereCondition, params string[] selectors)
        {
            var entity = Get(whereCondition);

            selectors.ToList().ForEach(s => DataContext.OC.LoadProperty(entity, s));
            return entity;
        }

        public virtual int AddWithSave(T entity)
        {
            DB.Set<T>().Add(entity);
            DataContext.Save();
            return entity.Id;

        }
        public virtual void Add(T entity)
        {
            DB.Set<T>().Add(entity);
        }

        public virtual void Remove(T entity)
        {
            DB.Set<T>().Remove(entity);
        }
        public virtual void RemoveWithSave(T entity)
        {
            DB.Set<T>().Remove(entity);
            DataContext.Save();
        }
        public virtual TColl ListAll()
        {
            var de = new TColl();
            var query = DB.Set<T>().AsQueryable();
            de.AddRange(query);
            return de;
        }
        public virtual TColl ListAll(Expression<Func<T, bool>> whereCondition)
        {
            var de = new TColl();
            var query = DB.Set<T>().AsQueryable();
            query = (System.Data.Entity.Infrastructure.DbQuery<T>)query.Where(whereCondition);
            de.AddRange(query);
            return de;
        }
        public virtual TColl ListAll(Expression<Func<T, bool>> whereCondition, params string[] selectors)
        {
            var de = new TColl();
            var query = DB.Set<T>().AsQueryable();
            selectors.ToList().ForEach(sel => query = query.Include(sel));
            query = (System.Data.Entity.Infrastructure.DbQuery<T>)query.Where(whereCondition);
            de.AddRange(query);
            return de;
        }

        public virtual int Count(Expression<Func<T, bool>> whereCondition)
        {
            return DB.Set<T>().Count(whereCondition);
        }
    }
}
