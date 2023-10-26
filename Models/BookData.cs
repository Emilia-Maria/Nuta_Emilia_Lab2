namespace Nuta_Emilia_Lab2.Models
{
    public class BookData
    {
        public IEnumerable<Book>? Books { get; set;}
        public IEnumerable<Category>? Categories { get; set;}
        public IEnumerable<BookCategory>? bookCategories { get; set;}
    }
}
