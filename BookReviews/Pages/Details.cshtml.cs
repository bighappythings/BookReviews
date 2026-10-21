using BookReviews.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using BookReviews.Models;

namespace BookReviews.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly BookDbContext context;

        public DetailsModel(BookDbContext context)
        {
            this.context = context;
        }

        public Book? Books { get; set; } = default;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return RedirectToPage("./Index");
            }

            var books = await context.Books.FirstOrDefaultAsync(equals => equals.Id == id);

            if (books == null)
            {
                return RedirectToPage("/Index");
            }
            else
            {
                Books = books;
                return Page();
            }
        }
    }
}
