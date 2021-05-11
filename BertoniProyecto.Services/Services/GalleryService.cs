using BertoniProyecto.Entities.Models;
using BertoniProyecto.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BertoniProyecto.Services.Services
{
    public class GalleryService : IGalleryService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public GalleryService(IHttpClientFactory clientFactory)
        {
            _httpClientFactory = clientFactory;
        }

        public async Task<List<Album>> GetAllAlbums()
        {
            var clientAlbums = await _httpClientFactory.CreateClient("Api").GetAsync("/albums");
            var JsonResult = await clientAlbums.Content.ReadAsStringAsync();
            List<Album> albums = JsonConvert.DeserializeObject<List<Album>>(JsonResult);

            return albums;
        }

        public async Task<List<Photo>> GetDataByAlbumId(int albumId)
        {
            var clientPhotos = await _httpClientFactory.CreateClient("Api").GetAsync("/photos");
            var JsonResultPhotos = await clientPhotos.Content.ReadAsStringAsync();
            List<Photo> photos = JsonConvert.DeserializeObject<List<Photo>>(JsonResultPhotos).Where(p => p.AlbumId == albumId).ToList();

            var comments = await GetCommentsByPhotoId(albumId);

            foreach (var photo in photos)
            {
                photo.Comments = comments.Where(c => c.PostId == photo.AlbumId).ToList();
            }

            return photos;
        }

        public async Task<List<Comment>> GetCommentsByPhotoId(int albumId)
        {
            var clientComments = await _httpClientFactory.CreateClient("Api").GetAsync("/comments");
            var JsonResultComments = await clientComments.Content.ReadAsStringAsync();

            List<Comment> comments = JsonConvert.DeserializeObject<List<Comment>>(JsonResultComments).Where(p => p.PostId == albumId).ToList();
            return comments;
        }
    }
}
