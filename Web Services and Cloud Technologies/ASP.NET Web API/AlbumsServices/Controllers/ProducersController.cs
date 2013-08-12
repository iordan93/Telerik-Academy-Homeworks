using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using AlbumsModel;
using AlbumsData;
using AlbumsRepositories;

namespace AlbumsServices.Controllers
{
    public class ProducersController : ApiController
    {
        private readonly IRepository<Producer> producersRepository;
        private readonly ModelBuilder modelBuilder;

        public ProducersController(
            IRepository<Producer> producersRepository, 
            ModelBuilder modelBuilder)
        {
            this.producersRepository = producersRepository;
            this.modelBuilder = modelBuilder;
        }


        // GET api/Producers
        public IEnumerable<Producer> GetProducers()
        {
            return this.producersRepository.GetAll().ToList();
        }

        // GET api/Producers/5
        public Producer GetProducer(int id)
        {
            Producer producer = this.producersRepository.GetSingle(id);
            if (producer == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return producer;
        }

        // PUT api/Producers/5
        public HttpResponseMessage PutProducer(int id, Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                Producer producerToUpdate = this.modelBuilder.BuildProducer(producer);
                this.producersRepository.Update(id, producerToUpdate);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Producers
        public HttpResponseMessage PostProducer(Producer producer)
        {
            if (ModelState.IsValid)
            {
                Producer producerToCreate = this.modelBuilder.BuildProducer(producer, true);
                this.producersRepository.Create(producerToCreate);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, producer);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = producer.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Producers/5
        public HttpResponseMessage DeleteProducer(int id)
        {
            Producer producer = this.producersRepository.GetSingle(id);
            if (producer == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
                this.producersRepository.Delete(id);                
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, producer);
        }

        protected override void Dispose(bool disposing)
        { 
        }
    }
}