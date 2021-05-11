using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BertoniProyecto.Models
{
    public class AlbumViewModel
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public List<PhotoViewModel> Photos { get; set; }
    }
}
