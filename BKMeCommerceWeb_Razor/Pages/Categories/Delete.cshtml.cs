using BKMeCommerceWeb_Razor.Data;
using BKMeCommerceWeb_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BKMeCommerceWeb_Razor.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public Category Category { get; set; }

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet(int? categoryId)
        {
            if (categoryId != null || categoryId != 0)
            {
                Category = _context.Categories.Find(categoryId);
            }
        }

        public IActionResult OnPost()
        {
            Category? category = _context.Categories.Find(Category.Id);
            if (category == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToPage("Index");
        }
    }
}
