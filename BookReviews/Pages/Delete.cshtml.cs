using BookReviews.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookReviews.Models;

namespace BookReviews.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly BookDbContext context;

        public DeleteModel(BookDbContext context)
        {
            this.context = context;
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return RedirectToPage("./Index");
            }

            var book = await context.Books.FirstOrDefaultAsync(e => e.Id == id);

            if (book == null)
            {
                return RedirectToPage("/Index");
            }

            Book = book;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return Page();
            }

            var book = await context.Books.FindAsync(id);

            if (book != null)
            {
                context.Books.Remove(book);
                await context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
