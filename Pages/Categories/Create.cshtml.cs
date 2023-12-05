using BulkyWebRazor.Data;
using BulkyWebRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor.Pages.Categories
{
    [BindProperties]
    public class CreateModel(AppDbContext dbContext) : PageModel
    {
        private readonly AppDbContext dbContext = dbContext;
        public Category Category { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            dbContext.Categories.Add(Category);
            dbContext.SaveChanges();
            TempData["success"] = "Category created successfully";
            return RedirectToPage("Index");
        }
    }
}
