namespace TheWaterProject.Models
{
    public interface IWaterRepository
    {
        // Property to retrieve a queryable collection of books
        public IQueryable<Book> Books { get; }
    }
}
