using BookaBook.Models;

namespace BookaBook.ModelView
{
    public class LivreFavorisModelView
    {
        public Livre Livre { get; set; } = null!;
        public double NoteMoyenne { get; set; }
        public bool IsTop1 { get; set; }
    }
}
