using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml;


namespace SpaceData
{
    class Program
    {

        static List<Astronaut> astronauts = new List<Astronaut>()
        {
        new Commander(1, "Stark"),
        new Pilot(2, "Hulk"),
        new Scientist(3, "Parker")
        };
        static List<Mission> missions = new List<Mission>();
        static int astronautCounter = 1;
        static int missionCounter = 1;

        public static void Main(string[] args)
        {
            bool exit = false;
            while(!exit) 
            {
                Console.WriteLine("1. Add Astronaut\n" +
                             "2. Edit Astronaut\n" +
                             "3. Delete Astronaut\n" +
                             "4. View Astronauts\n" +
                             "5. Search Astronaut\n" +
                             "6. Add Mission\n" +
                             "7. Edit Mission\n" +
                             "8. Delete Mission\n" +
                             "9. View Missions\n" +
                             "10. Assign Astronaut to Mission\n" +
                             "11. Exit\n");
                Console.WriteLine("Pick a number for desired action: ");

                int i;
                string option = Console.ReadLine();
                bool choice = int.TryParse(option, out i);

                
                if (choice) // if user input numeric
                {
                    switch (Int32.Parse(option))
                    {
                        case 1:
                            AddAstronaut();
                            break;
                        case 2:
                            EditAstronaut();
                            break;
                        case 3:
                            DeleteAstronaut();
                            break;
                        case 4:
                            ViewAstronauts();
                            break;
                        case 5:
                            SearchAstronaut();
                            break;
                        case 6:
                            AddMission();
                            break;
                        case 7:
                            EditMission();
                            break;
                        case 8:
                            DeleteMission();
                            break;
                        case 9:
                            ViewMissions();
                            break;
                        case 10:
                            AssignAstronautToMission();
                            break;
                        case 11:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice! Press any key to try again.");
                            Console.ReadKey();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input! Press any key to try again.");
                    Console.ReadKey();
                }
            }
        }

        // Add Astronaut
        private static void AddAstronaut()
        {
            Console.WriteLine("Add Astronaut\n" + 
                        "1. Commander\n" +
                        "2. Pilot\n" +
                        "3. Scientist\n" +
                        "4. Engineer\n" + 
                        "5. Back to Main Menu");
            Console.Write("Enter your choice: ");

            int i;
            string option = Console.ReadLine();
            bool choice = int.TryParse(option, out i);

            if (choice) // if user input is numeric 
            {
                if (Int32.Parse(option) >= 1 && Int32.Parse(option) <= 4)
                {
                    Console.WriteLine("Enter name: ");
                    string name = Console.ReadLine();

                    // Reference type null will change later to be populated 
                    Astronaut astronaut = null;
                    switch (Int32.Parse(option))
                    {
                        case 1: // Add new commander and inc
                            astronaut = new Commander(astronautCounter++, name);
                            break;
                        case 2: // Add new pilot and inc
                            astronaut = new Pilot(astronautCounter++, name);
                            break;
                        case 3: // Add new scientist and inc
                            astronaut = new Scientist(astronautCounter++, name);
                            break;
                        case 4: // Add new engineer and inc
                            astronaut = new Engineer(astronautCounter++, name);
                            break;
                        default:
                            break;
                    }

                    if (astronaut != null)
                    {
                        astronauts.Add(astronaut);
                        Console.WriteLine("Astronaut added successfully!");
                    }
                }
            }
            else if (Int32.Parse(option) != 5)
            {
                Console.WriteLine("Invalid choice! Press any key to try again...");
            }
            Console.ReadKey();
        }

        // Edit astronaut
        private static void EditAstronaut()
        {
            Console.WriteLine("Edit Astronaut");
            ViewAstronauts();

            Console.Write("Enter the ID of the astronaut to edit: ");
            bool austroId = int.TryParse(Console.ReadLine(), out int id);
            if (austroId)
            {
                Astronaut astronaut = astronauts.FirstOrDefault(a => a.ID == id);
                if (astronaut != null)
                {
                    Console.Write("Enter new name: ");
                    astronaut.Name = Console.ReadLine();
                    Console.WriteLine("Astronaut updated successfully!");
                }
                else
                {
                    Console.WriteLine("Astronaut not found!");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID! Press any key to try again...");
            }

            Console.ReadKey();
        }

        private static void DeleteAstronaut()
        {
            Console.WriteLine("Delete an Astronaut");
            ViewAstronauts();
            Console.WriteLine("Enter ID of astronaut to be deleted: ");

            bool astroId = int.TryParse(Console.ReadLine(), out int id);
            if (astroId)
            {
                Astronaut astronaut = astronauts.FirstOrDefault(a => a.ID == id);
                if (astronaut != null)
                {
                    astronauts.Remove(astronaut);
                    Console.WriteLine("Astronaut deleted successfully!");
                }
                else
                {
                    Console.WriteLine("Astronaut not found!");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID! Press any key to try again...");
            }

            Console.ReadKey();
        }

        private static void ViewAstronauts()
        {
            Console.Write("View Astronauts\n");
            foreach (var astronaut in astronauts)
            {
                Console.WriteLine(astronaut);
            }
            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
        }

        private static void SearchAstronaut()
        {
            Console.Write("Search astronaut by name: ");
            string name = Console.ReadLine();
            var results = astronauts.Where(a => a.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();

            if (results.Count > 0) 
            {
                foreach (var astronaut in results)
                {
                    Console.WriteLine(astronaut);
                }
            } else
            {
                Console.WriteLine("No astronauts found.");
            }
            Console.WriteLine("Press a key to exit");
            Console.ReadKey();
        }

        private static void AddMission()
        {
            Console.Clear();
            Console.WriteLine("Add Mission");

            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Console.Write("Enter launch date (YYYY-MM-DD): ");
            DateTime launchDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter duration (days): ");
            int duration = int.Parse(Console.ReadLine());

            Mission mission = new Mission(missionCounter++, name, launchDate, duration);
            missions.Add(mission);

            Console.WriteLine("Mission added successfully!");
            Console.ReadKey();
        }

        private static void EditMission()
        {
            Console.Clear();
            Console.WriteLine("Edit Mission");
            ViewMissions();

            Console.Write("Enter the ID of the mission to edit: ");
            bool austroId = int.TryParse(Console.ReadLine(), out int id);
            if (austroId)
            {
                Mission mission = missions.FirstOrDefault(m => m.ID == id);
                if (mission != null)
                {
                    Console.Write("Enter new name: ");
                    mission.Name = Console.ReadLine();

                    Console.Write("Enter new launch date (YYYY-MM-DD): ");
                    mission.LaunchDate = DateTime.Parse(Console.ReadLine());

                    Console.Write("Enter new duration (days): ");
                    mission.Duration = int.Parse(Console.ReadLine());

                    Console.WriteLine("Mission updated successfully!");
                }
                else
                {
                    Console.WriteLine("Mission not found!");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID! Press any key to try again...");
            }

            Console.ReadKey();
        }


        static void DeleteMission()
        {
            Console.Clear();
            Console.WriteLine("Delete Mission");
            ViewMissions();

            Console.Write("Enter the ID of the mission to delete: ");
            bool austroId = int.TryParse(Console.ReadLine(), out int id);
            if (austroId)
            {
                Mission mission = missions.FirstOrDefault(m => m.ID == id);
                if (mission != null)
                {
                    missions.Remove(mission);
                    Console.WriteLine("Mission deleted successfully!");
                }
                else
                {
                    Console.WriteLine("Mission not found!");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID! Press any key to try again...");
            }

            Console.ReadKey();
        }

        static void ViewMissions()
        {
            Console.Clear();
            Console.WriteLine("View Missions");
            foreach (var mission in missions)
            {
                Console.WriteLine(mission);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void AssignAstronautToMission()
        {
            Console.Clear();
            Console.WriteLine("Assign Astronaut to Mission");
            ViewMissions();
            Console.Write("Enter the ID of the mission: ");
            bool missId = int.TryParse(Console.ReadLine(), out int missionId);
            if (missId)
            {
                Mission mission = missions.FirstOrDefault(m => m.ID == missionId);
                if (mission != null)
                {
                    ViewAstronauts();
                    Console.Write("Enter the ID of the astronaut to assign: ");
                    bool austroId = int.TryParse(Console.ReadLine(), out int austronautId);
                    if (austroId)
                    {
                        Astronaut astronaut = astronauts.FirstOrDefault(a => a.ID == austronautId);
                        if (astronaut != null)
                        {
                            mission.AssignedAstronauts.Add(astronaut);
                            Console.WriteLine("Astronaut assigned to mission successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Astronaut not found!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID! Press any key to try again...");
                    }
                }
                else
                {
                    Console.WriteLine("Mission not found!");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID! Press any key to try again...");
            }

            Console.ReadKey();
        }

    }

}