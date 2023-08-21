using IssueTracker.Models;

namespace IssueTracker.Extensions
{
    public static class PriorityExtensions
    {
        static readonly Dictionary<Priority, string> _priorityCssClasses = new()
        {
            [Priority.High] = "badge bg-danger",
            [Priority.Medium] = "badge bg-warning text-dark",
            [Priority.Low] = "badge bg-sucess"
        };

        public static string ToCssClass(this Priority priority) => _priorityCssClasses[priority];
    }
}
