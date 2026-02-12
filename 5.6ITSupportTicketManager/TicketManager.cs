using System;
using System.Collections.Generic;
using System.IO;

namespace ITSupportTicketManager
{
    public class TicketManager
    {
        private List<Ticket> _tickets = new List<Ticket>();

        public void AddTicket(Ticket t)
        {
            _tickets.Add(t);
        }

        public Ticket FindTicket(string id)
        {
            return _tickets.Find(t => t.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        public void DisplayAllTickets()
        {
            if (_tickets.Count == 0)
            {
                Console.WriteLine("No tickets found.");
                return;
            }

            foreach (Ticket t in _tickets)
            {
                Console.WriteLine(t.GetSummary());
            }
        }

        public void SaveTickets(string path)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    writer.WriteLine("Id,Description,Priority,Status,DateCreated");

                    foreach (Ticket t in _tickets)
                    {
                        writer.WriteLine($"{t.Id},{t.Description},{t.Priority},{t.Status},{t.DateCreated:o}");
                    }
                }

                Console.WriteLine("Tickets saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving file: {ex.Message}");
            }
        }

        public void LoadTickets(string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    Console.WriteLine("File not found.");
                    return;
                }

                _tickets.Clear();

                using (StreamReader reader = new StreamReader(path))
                {
                    string line;
                    bool firstLine = true;

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (firstLine)
                        {
                            firstLine = false;
                            continue;
                        }

                        string[] parts = line.Split(',');

                        if (parts.Length != 5)
                        {
                            Console.WriteLine("Skipped line: Invalid column count");
                            continue;
                        }

                        try
                        {
                            Ticket t = new Ticket
                            {
                                Id = parts[0],
                                Description = parts[1],
                                Priority = parts[2],
                                Status = parts[3],
                                DateCreated = DateTime.Parse(parts[4])
                            };

                            _tickets.Add(t);
                        }
                        catch
                        {
                            Console.WriteLine("Skipped line: Invalid data format");
                        }
                    }
                }

                Console.WriteLine("Tickets loaded successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading file: {ex.Message}");
            }
        }
    }
}
