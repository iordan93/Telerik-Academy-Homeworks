using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using StudentsModels;
using StudentsData;
using StudentsRepositories;

namespace StudentsServices.Controllers
{
    public class SchoolsController : ApiController
    {
        private readonly IRepository<School> schoolsRepository;

        public SchoolsController(IRepository<School> schoolsRepository)
        {
            this.schoolsRepository = schoolsRepository;
        }

        // GET api/Schools
        public IEnumerable<SchoolModel> GetSchools()
        {
            var schools = this.schoolsRepository.GetAll()
                              .Include(s => s.Students)
                              .Include(s => s.Students
                                             .Select(st => st.Marks)).ToList();
            List<SchoolModel> schoolModels = new List<SchoolModel>();
            foreach (var school in schools)
            {
                schoolModels.Add(ModelConverter.ConvertSchool(school));
            }

            return schoolModels;
        }

        // GET api/Schools/5
        public SchoolModel GetSchool(int id)
        {
            School school = this.schoolsRepository.GetAll()
                                .Include(s => s.Students)
                                .Include(s => s.Students
                                               .Select(st => st.Marks))
                                .FirstOrDefault(s => s.Id == id);
            if (school == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return ModelConverter.ConvertSchool(school);
        }

        // POST api/Schools
        public HttpResponseMessage PostSchool(School school)
        {
            if (ModelState.IsValid)
            {
                SchoolModel schoolModel;
                School repositorySchool = this.schoolsRepository.GetAll().
                Include(s => s.Students).
                Include(s => s.Students.Select(st => st.Marks))
                                              .FirstOrDefault(s => s.Name == school.Name &&
                                                                   s.Location == school.Location);
                if (repositorySchool != null)
                {
                    schoolModel = ModelConverter.ConvertSchool(repositorySchool);
                }
                else
                {
                    this.schoolsRepository.Create(school);
                    schoolModel = ModelConverter.ConvertSchool(school);
                }

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, schoolModel);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = school.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
    }
}