using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameCollection_WinForms.Models
{
    public class Game(bool isNew)
    {
        public int VGID { get; set; }
        public required string Title { get; set; }
        public required string Platform { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string ReleaseYear { get; set; } = string.Empty;
        public string Developer { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public bool Physical { get; set; } = true;
        public bool IsNew { get; set; } = isNew;
    }
}
