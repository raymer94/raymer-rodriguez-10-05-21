using BertoniProyecto.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BertoniProyecto.Services.Interfaces
{
    public interface IGalleryService
    {
        Task<List<Album>> GetAllAlbums();
        Task<List<Photo>> GetDataByAlbumId(int albumId);
        Task<List<Comment>> GetCommentsByPhotoId(int photoId);
    }
}
