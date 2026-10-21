using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookReviews.Models;
using BookReviews.Data;

namespace BookReviews.Pages
{
    public class BooksModel : PageModel
    {
        private readonly BookDbContext _context;

        public List<Book> Books { get; set; } = new List<Book>();

        [BindProperty]

        public Book NewBook { get; set; }

        public BooksModel(BookDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Books = _context.Books.ToList();
        }

        public IActionResult OnPost()
        {
            _context.Books.Add(NewBook);
            _context.SaveChanges();

            return RedirectToPage();
        }
    }
}
