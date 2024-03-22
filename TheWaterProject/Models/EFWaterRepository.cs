
namespace TheWaterProject.Models
{
    public class EFWaterRepository : IWaterRepository
    {
        private WaterProjectContext _context;
        public EFWaterRepository(WaterProjectContext temp)
        {
            _context = temp;
        }
        public IQueryable<Book> Books => _context.Books;
    }
}
