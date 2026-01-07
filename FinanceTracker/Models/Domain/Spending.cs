using Microsoft.AspNetCore.Identity;

namespace FinanceTracker.Models.Domain
{
    public class Spending
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
