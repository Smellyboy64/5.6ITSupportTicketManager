using System;

namespace ITSupportTicketManager
{
    public class Ticket
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; } // Low, Medium, High
        public string Status { get; set; }   // Open, In Progress, Closed
        public DateTime DateCreated { get; set; }

        // Default constructor
        public Ticket()
        {
            DateCreated = DateTime.Now;
            Status = "Open";
        }

        // Overloaded constructor
        public Ticket(string id, string description, string priority, string status)
        {
            Id = id;
            Description = description;
            Priority = priority;
            Status = status;
            DateCreated = DateTime.Now;
        }

        public void CloseTicket()
        {
            Status = "Closed";
        }

        public void ReopenTicket()
        {
            Status = "Open";
        }

        public string GetSummary()
        {
            return $"[{Id}] ({Priority}) - \"{Description}\" | Status: {Status} | Created: {DateCreated:yyyy-MM-dd}";
        }
    }
}
