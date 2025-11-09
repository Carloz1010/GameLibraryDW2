using GameLibrary.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Domain.DTOs
{
    public class CreateGameDTO
    {
        public string SKU { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public GamePlatform Platform { get; set; }
        public GameRegion Region { get; set; }
        public GameFormat Format { get; set; }
        public string Genre { get; set; } = null!;
        public string Developer { get; set; } = null!;
        public DateTime ReleaseDate { get; set; }
    }
}
