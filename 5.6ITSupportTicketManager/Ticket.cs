using System;

public class Ticket
{
    public string Id { get; set; }
    public string Description { get; set; }
    public string Priority { get; set; } 
    public string Status { get; set; }   
    public DateTime DateCreated { get; set; }

    public Ticket()
    {
        DateCreated = DateTime.Now;
        Status = "Open";
    }

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
