namespace StudentsRepositories
{
    using System;
    using System.Linq;

    public interface IRepository<T> where T : class
    {
        void Create(T item);

        IQueryable<T> GetAll();

        T GetSingle(int id);

        void Update(int id, T item);

        void Delete(int id);

        void Delete(T item);
    }
}