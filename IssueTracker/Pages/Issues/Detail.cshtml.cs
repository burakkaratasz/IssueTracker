using IssueTracker.Data;
using IssueTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IssueTracker.Pages.Issues
{
    public class DetailModel : PageModel
    {
        private readonly IssueDbContext _context;
        public DetailModel(IssueDbContext context) => _context = context;

        public async void OnGet(uint id) => Issue = await _context.Issues.FindAsync(id);

        public async void OnGetResolve(uint id)
        {
            var issueToUpdate = _context.Issues.SingleOrDefault(i => i.Id == id);
            if (issueToUpdate == null) return;

            issueToUpdate.Completed = DateTime.Now;
            _context.Update(issueToUpdate);
            await _context.SaveChangesAsync();

        }

        public Issue? Issue { get; private set; }
    }
}
