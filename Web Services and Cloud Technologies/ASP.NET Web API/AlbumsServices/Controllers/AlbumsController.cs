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
    public class AlbumsController : ApiController
    {
        private readonly IRepository<Album> albumsRepository;
        
        private readonly ModelBuilder modelBuilder;

        public AlbumsController(
            IRepository<Album> albumsRepository, ModelBuilder modelBuilder)
        {
            this.albumsRepository = albumsRepository;
            this.modelBuilder = modelBuilder;
        }

        // GET api/Albums
        public IEnumerable<AlbumModel> GetAlbums()
        {
            var albums = albumsRepository.GetAll().ToList();

            HashSet<AlbumModel> albumsModelAll = new HashSet<AlbumModel>();
            foreach (var album in albums)
            {
                AlbumModel albumModel = ModelConverter.ConvertAlbum(album);
                albumsModelAll.Add(albumModel);
            }

            return albumsModelAll.AsEnumerable();
        }

        // GET api/Albums/5
        public AlbumModel GetAlbum(int id)
        {
            Album album = albumsRepository.GetSingle(id);

            if (album == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            else
            {
                AlbumModel albumModel = ModelConverter.ConvertAlbum(album);
                return albumModel;
            }
        }

        // PUT api/Albums/5
        public HttpResponseMessage PutAlbum(int id, Album album)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                Album albumToUpdate = this.modelBuilder.BuildAlbum(album);
                albumToUpdate.Id = id;

                this.albumsRepository.Update(id, albumToUpdate);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Albums
        public HttpResponseMessage PostAlbum(Album album)
        {
            if (ModelState.IsValid)
            {
                Album albumToCreate = this.modelBuilder.BuildAlbum(album, true);
                this.albumsRepository.Create(albumToCreate);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, album);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = album.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Albums/5
        public HttpResponseMessage DeleteAlbum(int id)
        {
            Album album = this.albumsRepository.GetSingle(id);
            if (album == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
                this.albumsRepository.Delete(album);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, album);
        }

        protected override void Dispose(bool disposing)
        {
        }
    }
}