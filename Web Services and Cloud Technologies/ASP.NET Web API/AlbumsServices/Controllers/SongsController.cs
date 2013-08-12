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
    public class SongsController : ApiController
    {

        private readonly IRepository<Song> songsRepository;
        private readonly ModelBuilder modelBuilder;

        public SongsController(
            IRepository<Song> songsRepository,
            ModelBuilder modelBuilder)
        {
            this.songsRepository = songsRepository;
            this.modelBuilder = modelBuilder;
        }

        // GET api/Songs
        public IEnumerable<SongModel> GetSongs()
        {
            var songs = this.songsRepository.GetAll().Include(s => s.Artist).Include(s => s.Artist.Country).ToList();

            HashSet<SongModel> songsModelAll = new HashSet<SongModel>();
            foreach (var song in songs)
            {
                SongModel songModel = ModelConverter.ConvertSong(song);
                songsModelAll.Add(songModel);
            }

            return songsModelAll.AsEnumerable();
        }

        // GET api/Songs/5
        public SongModel GetSong(int id)
        {
            Song song = this.songsRepository.GetSingle(id);

            if (song == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            else
            {
                SongModel songModel = ModelConverter.ConvertSong(song);
                return songModel;
            }
        }

        // PUT api/Songs/5
        public HttpResponseMessage PutSong(int id, Song song)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                Song songToUpdate = modelBuilder.BuildSong(song);
                songToUpdate.Id = id;

                this.songsRepository.Update(id, songToUpdate);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Songs
        public HttpResponseMessage PostSong(Song song)
        {
            if (ModelState.IsValid)
            {
                Song songToCreate = this.modelBuilder.BuildSong(song, true);
                this.songsRepository.Create(songToCreate);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, song);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = song.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Songs/5
        public HttpResponseMessage DeleteSong(int id)
        {
            Song song = this.songsRepository.GetSingle(id);
            if (song == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
                this.songsRepository.Delete(id);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, song);
        }

        protected override void Dispose(bool disposing)
        {
        }
    }
}