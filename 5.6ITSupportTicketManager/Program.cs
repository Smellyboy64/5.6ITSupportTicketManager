using System;

namespace ITSupportTicketManager
{
    class Program
    {
        static void Main()
        {
            TicketManager manager = new TicketManager();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n=== IT Support Ticket Manager ===");
                Console.WriteLine("1. Add Ticket");
                Console.WriteLine("2. Display All");
                Console.WriteLine("3. Close Ticket");
                Console.WriteLine("4. Reopen Ticket");
                Console.WriteLine("5. Save Tickets");
                Console.WriteLine("6. Load Tickets");
                Console.WriteLine("7. Exit");
                Console.Write("Choose: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddTicket(manager);
                        break;

                    case "2":
                        manager.DisplayAllTickets();
                        break;

                    case "3":
                        CloseTicket(manager);
                        break;

                    case "4":
                        ReopenTicket(manager);
                        break;

                    case "5":
                        Console.Write("Enter file path to save: ");
                        manager.SaveTickets(Console.ReadLine());
                        break;

                    case "6":
                        Console.Write("Enter file path to load: ");
                        manager.LoadTickets(Console.ReadLine());
                        break;

                    case "7":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        static void AddTicket(TicketManager manager)
        {
            Console.Write("Enter Ticket ID: ");
            string id = Console.ReadLine();

            Console.Write("Enter Description: ");
            string description = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(description))
            {
                Console.WriteLine("Description cannot be empty.");
                return;
            }

            Console.Write("Enter Priority (Low/Medium/High): ");
            string priority = Console.ReadLine();
            if (priority != "Low" && priority != "Medium" && priority != "High")
            {
                Console.WriteLine("Invalid priority.");
                return;
            }

            Ticket t = new Ticket(id, description, priority, "Open");
            manager.AddTicket(t);

            Console.WriteLine("Ticket added successfully!");
        }

        static void CloseTicket(TicketManager manager)
        {
            Console.Write("Enter Ticket ID to close: ");
            string id = Console.ReadLine();

            Ticket t = manager.FindTicket(id);
            if (t == null)
            {
                Console.WriteLine("Ticket not found.");
                return;
            }

            t.CloseTicket();
            Console.WriteLine("Ticket closed.");
        }

        static void ReopenTicket(TicketManager manager)
        {
            Console.Write("Enter Ticket ID to reopen: ");
            string id = Console.ReadLine();

            Ticket t = manager.FindTicket(id);
            if (t == null)
            {
                Console.WriteLine("Ticket not found.");
                return;
            }

            t.ReopenTicket();
            Console.WriteLine("Ticket reopened.");
        }
    }
}
