using BulkyWebRazor.Data;
using BulkyWebRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor.Pages.Categories
{
    public class IndexModel(AppDbContext dbContext) : PageModel
    {
        private readonly AppDbContext dbContext = dbContext;

        public List<Category> CategoryList { get; set; }
        public void OnGet()
        {
            CategoryList = [.. dbContext.Categories];
        }
    }
}
