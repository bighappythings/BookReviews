using BookReviews.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using BookReviews.Models;

namespace BookReviews.Pages
{
    public class EditModel : PageModel
    {
        private readonly BookDbContext context;

        public EditModel(BookDbContext context)
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

            var book = await context.Books.FirstOrDefaultAsync(equals => equals.Id == id);

            if (book == null)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                Book = book;
                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            context.Books.Update(Book);
            await context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
