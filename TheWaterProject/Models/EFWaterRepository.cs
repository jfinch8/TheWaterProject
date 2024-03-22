
namespace TheWaterProject.Models
{
    // Implementation of the IWaterRepository interface using Entity Framework
    public class EFWaterRepository : IWaterRepository
    {
        private WaterProjectContext _context;

        // Constructor to initialize the repository with an instance of WaterProjectContext
        public EFWaterRepository(WaterProjectContext temp)
        {
            _context = temp;
        }
        // Property to provide access to the collection of books in the context
        public IQueryable<Book> Books => _context.Books;
    }
}
