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
    public class ArtistsController : ApiController
    {
        private readonly IRepository<Artist> artistsRepository;
        private readonly ModelBuilder modelBuilder;

        public ArtistsController(
            IRepository<Artist> artistsRepository,
            ModelBuilder modelBuilder)
        {
            this.artistsRepository = artistsRepository;
            this.modelBuilder = modelBuilder;
        }

        // GET api/Artists
        public IEnumerable<ArtistModel> GetArtists()
        {
            var artists = this.artistsRepository.GetAll().Include(a => a.Country).ToList();
            HashSet<ArtistModel> artistsModelAll = new HashSet<ArtistModel>();
            foreach (var artist in artists)
            {
                ArtistModel artistModel = ModelConverter.ConvertArtist(artist);

                artistsModelAll.Add(artistModel);
            }

            return artistsModelAll.AsEnumerable();
        }

        // GET api/Artists/5
        public ArtistModel GetArtist(int id)
        {
            Artist artist = this.artistsRepository.GetSingle(id);
            if (artist == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            else
            {
                ArtistModel artistModel = ModelConverter.ConvertArtist(artist);
                return artistModel;
            }
        }

        // PUT api/Artists/5
        public HttpResponseMessage PutArtist(int id, Artist artist)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                Artist artistToUpdate = this.modelBuilder.BuildArtist(artist);
                artistToUpdate.Id = id;

                this.artistsRepository.Update(id, artistToUpdate);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Artists
        public HttpResponseMessage PostArtist(Artist artist)
        {
            if (ModelState.IsValid)
            {
                Artist artistToCreate = this.modelBuilder.BuildArtist(artist, true);
                this.artistsRepository.Create(artistToCreate);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, artist);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = artist.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Artists/5
        public HttpResponseMessage DeleteArtist(int id)
        {
            Artist artist = this.artistsRepository.GetSingle(id);
            if (artist == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
                this.artistsRepository.Delete(artist);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, artist);
        }

        protected override void Dispose(bool disposing)
        {
        }
    }
}