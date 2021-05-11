using AutoMapper;
using BertoniProyecto.Entities.Models;
using BertoniProyecto.Models;
using BertoniProyecto.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BertoniProyecto.Controllers
{
    public class GalleryController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IGalleryService _IgalleryService;

        public GalleryController(IMapper mapper, IGalleryService galleryService)
        {
            _mapper = mapper;
            _IgalleryService = galleryService;
        }

        public async Task<IActionResult> Index()
        {
            List<Album> albums = await _IgalleryService.GetAllAlbums();
            List<AlbumViewModel> albumViewModels = _mapper.Map<List<AlbumViewModel>>(albums);

            return View(albumViewModels);
        }

        public async Task<IActionResult> Pictures(int albumId)
        {

            List<Photo> photos = await _IgalleryService.GetDataByAlbumId(albumId);
            List<PhotoViewModel> photoViewModel = _mapper.Map<List<PhotoViewModel>>(photos);

            return View(photoViewModel);
        }
    }
}
