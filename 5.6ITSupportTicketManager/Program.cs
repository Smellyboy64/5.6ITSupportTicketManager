using System; 

namespace _5._6ITSupportTicketManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TicketManager manager = new TicketManager();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n=== IT Support Ticket Manager ===");
                Console.WriteLine("1. Add Ticket");
                Console.WriteLine("2. Display All Tickets");
                Console.WriteLine("3. Exit");
                Console.Write("Choose: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Ticket ID: ");
                        string id = Console.ReadLine();

                        Console.Write("Enter Description: ");
                        string desc = Console.ReadLine();

                        Console.Write("Enter Priority (Low/Medium/High): ");
                        string priority = Console.ReadLine();

                        Ticket t = new Ticket(id, desc, priority, "Open");
                        manager.AddTicket(t);

                        Console.WriteLine("Ticket added.");
                        break;

                    case "2":
                        manager.DisplayAllTickets();
                        break;

                    case "3":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
