namespace StudentsTests
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http.Dependencies;
    using StudentsModels;
    using StudentsRepositories;
    using StudentsServices.Controllers;

    public class TestStudentsDependencyResolver<T> : IDependencyResolver where T : class
    {
        private IRepository<T> repository;

        public IRepository<T> Repository
        {
            get
            {
                return this.repository;
            }
            set
            {
                this.repository = value;
            }
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(StudentsController))
            {
                return new StudentsController(this.Repository as IRepository<Student>);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose()
        {
        }
    }
}