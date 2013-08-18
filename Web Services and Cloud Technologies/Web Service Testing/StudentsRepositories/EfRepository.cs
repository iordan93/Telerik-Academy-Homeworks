namespace StudentsRepositories
{
    using System;
    using System.Data;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Linq;

    public class EfRepository<T> : IRepository<T> where T : class
    {
        public EfRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use the EfRepository");
            }

            this.Context = context;
            this.DbSet = context.Set<T>();
        }

        protected DbContext Context { get; set; }

        protected IDbSet<T> DbSet { get; set; }

        public void Create(T item)
        {
            DbEntityEntry entry = this.Context.Entry(item);
            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                this.DbSet.Add(item);
            }

            this.Context.SaveChanges();
        }

        public virtual IQueryable<T> GetAll()
        {
            return this.DbSet;
        }

        public virtual T GetSingle(int id)
        {
            return this.DbSet.Find(id);
        }

        public void Update(int id, T item)
        {
            DbEntityEntry entry = this.Context.Entry(item);
            if (entry.State == EntityState.Detached)
            {
                T attachedEntry = this.DbSet.Find(id);
                if (attachedEntry != null)
                {
                    this.Context.Entry(attachedEntry).CurrentValues.SetValues(item);
                }
                else
                {
                    entry.State = EntityState.Modified;
                }
            }

            this.Context.SaveChanges();
        }

        public void Delete(int id)
        {
            T entity = this.GetSingle(id);

            if (entity != null)
            {
                this.Delete(entity);
            }
        }

        public virtual void Delete(T item)
        {
            DbEntityEntry entry = this.Context.Entry(item);
            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                this.DbSet.Attach(item);
                this.DbSet.Remove(item);
            }

            this.Context.SaveChanges();
        }
    }
}
