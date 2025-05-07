using System.Diagnostics.CodeAnalysis;

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

    public class GameComparer : IEqualityComparer<Game>
    {
        public bool Equals(Game? x, Game? y)
        {
            if (x == null || y == null) return false;
            return (x.VGID == y.VGID &&
                    x.Title == y.Title &&
                    x.Platform == y.Platform &&
                    x.Description == y.Description &&
                    x.Genre == y.Genre &&
                    x.ReleaseYear == y.ReleaseYear &&
                    x.Developer == y.Developer &&
                    x.Publisher == y.Publisher &&
                    x.Physical == y.Physical);
        }

        public int GetHashCode([DisallowNull] Game obj)
        {
            return obj.GetHashCode();
        }
    }
}
