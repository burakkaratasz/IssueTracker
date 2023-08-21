using IssueTracker.Data;
using IssueTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IssueTracker.Pages.Issues
{
    public class NewModel : PageModel
    {
        private readonly IssueDbContext _context;

        public NewModel(IssueDbContext context) => _context = context;
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();
            
            Issue.Created = DateTime.Now;
            await _context.Issues.AddAsync(Issue);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Index");
        }

        [BindProperty]
        public Issue Issue { get; set; } 
    }
}
