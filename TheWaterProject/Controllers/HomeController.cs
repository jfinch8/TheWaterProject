using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TheWaterProject.Models;
using TheWaterProject.Models.ViewModels;

namespace TheWaterProject.Controllers
{
    public class HomeController : Controller
    {
        private IWaterRepository _repo;

        // Constructor to initialize the controller with an instance of IWaterRepository
        public HomeController(IWaterRepository temp)
        {
            _repo = temp;
        }
        // Action method for the homepage
        // Takes an optional parameter for the page number
        public IActionResult Index(int pageNum)
        {
            // Number of items to display per page
            int pageSize = 10;

            // Query to retrieve books from the repository, ordered by title,
            // skipping items to implement pagination, and taking items for the current page
            var blah = new ProjectsListViewModel
            {
                Books = _repo.Books
                .OrderBy(x => x.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                // Creating pagination information to pass to the view
                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = _repo.Books.Count()

                }
        };

            // Returning the view with the ProjectsListViewModel containing the books and pagination info
            return View(blah);
        }

    }
}
