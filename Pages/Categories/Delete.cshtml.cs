using BulkyWebRazor.Data;
using BulkyWebRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor.Pages.Categories
{
    [BindProperties]
    public class DeleteModel(AppDbContext dbContext) : PageModel
    {
        private readonly AppDbContext dbContext = dbContext;

        public Category Category { get; set; }

        public void OnGet(int? id)
        {
            if(id != null && id != 0)
            {
                Category = dbContext.Categories.Find(id);
            }
        }

        public IActionResult OnPost()
        {
            Category? category = dbContext.Categories.Find(Category.Id);
            if(category is null)
                return NotFound();
            dbContext.Categories.Remove(category);
            dbContext.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToPage("Index");
        }
    }
}
