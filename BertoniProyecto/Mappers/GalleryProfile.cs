using AutoMapper;
using BertoniProyecto.Entities.Models;
using BertoniProyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BertoniProyecto.Mappers
{
    public class GalleryProfile : Profile
    {
        public GalleryProfile()
        {
            CreateMap<Album, AlbumViewModel>();
            CreateMap<Photo, PhotoViewModel>();
            CreateMap<Comment, CommentViewModel>();
        }
    }
}
