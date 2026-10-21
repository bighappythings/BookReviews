using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookReviews.Data;
using BookReviews.Models;

namespace BookReviews.Pages
{
    public class IndexModel : PageModel
    {

        private readonly BookDbContext context;

        public IndexModel(BookDbContext context)
        {
            this.context = context;
        }

        public IList<Book> Books { get; set; } = default!;
        public async Task OnGetAsync()
        {
            Books = await context.Books.ToListAsync();
        }
    }
}
