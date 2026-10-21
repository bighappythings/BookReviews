using BookReviews.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using BookReviews.Models;

namespace BookReviews.Pages
{
    public class CreateModel : PageModel
    {
        private readonly BookDbContext context;

        public CreateModel(BookDbContext context)
        {
            this.context = context;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = new();

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            context.Books.Add(Book);
            await context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
