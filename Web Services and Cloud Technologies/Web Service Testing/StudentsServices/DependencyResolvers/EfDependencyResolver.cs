using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using StudentsData;
using StudentsModels;
using StudentsRepositories;
using StudentsServices.Controllers;

namespace StudentsServices.DependencyResolvers
{
    public class EfDependencyResolver : IDependencyResolver
    {
        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(SchoolsController))
            {
                return new SchoolsController(new EfRepository<School>(new StudentsContext()));
            }
            else if (serviceType == typeof(StudentsController))
            {
                return new StudentsController(new EfRepository<Student>(new StudentsContext()));
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