

namespace SpaceData
{

    class Program
    {
        public static void Main(string[] args)
        {
            AMSData amsData = new AMSData();

            int choice;

            do
            {
                Console.WriteLine("\nAstronaut Management System");
                Console.WriteLine("1. Add Astronaut");
                Console.WriteLine("2. Edit Astronaut");
                Console.WriteLine("3. Delete Astronaut");
                Console.WriteLine("4. View Astronauts");
                Console.WriteLine("5. Search Astronaut");
                Console.WriteLine("6. Add Mission");
                Console.WriteLine("7. Edit Mission");
                Console.WriteLine("8. Delete Mission");
                Console.WriteLine("9. View Missions");
                Console.WriteLine("10. Assign Astronaut to Mission");
                Console.WriteLine("11. Exit");

                Console.Write("Enter your choice: ");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddAstronaut(amsData);
                        break;
                    case 2:
                        EditAstronaut(amsData);
                        break;
                    case 3:
                        DeleteAstronaut(amsData);
                        break;
                    case 4:
                        amsData.ViewAstronauts();
                        break;
                    // case 5:
                    //     SearchAstronauts(amsData);
                    //     break;
                    case 6:
                        AddMission(amsData);
                        break;
                    case 7:
                        EditMission(amsData);
                        break;
                    case 8:
                        DeleteMission(amsData);
                        break;
                    case 9:
                        amsData.ViewMissions(amsData);
                        break;
                    // case 10:
                    //     AssignAstronautToMission();
                    case 11:
                        Console.WriteLine("Exiting AMS...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            } while (choice != 11);
        }

        public static void AddAstronaut(AMSData amsData)
        {
            Console.WriteLine("\nAdd Astronaut");
            Console.WriteLine("1. Commander");
            Console.WriteLine("2. Pilot");
            Console.WriteLine("3. Scientist");
            Console.WriteLine("4. Engineer");
            Console.WriteLine("5. Back to Main Menu");

            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddCommander(amsData);
                    break;
                case 2:
                    AddPilot(amsData);
                    break;
                case 3:
                    AddScientist(amsData);
                    break;
                case 4:
                    AddEngineer(amsData);
                    break;
                case 5:
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
        private static void AddCommander(AMSData amsData)
        {
            string name;

            do
            {
                Console.Write("Enter name: ");
                name = Console.ReadLine();

                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Error: Name cannot be empty. Please enter a name.");
                }
            } while (string.IsNullOrEmpty(name));

            Console.Write("Enter experience (years): ");
            int experience = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter number of command missions: ");
            int commandMissions = Convert.ToInt32(Console.ReadLine());

            // Generate unique ID
            int id = amsData.Astronauts.Count + 1; // Adjust for your ID generation logic

            Commander commander = new Commander(id, name, experience, commandMissions);
            amsData.AddAstronaut(commander);
            Console.WriteLine("Commander added successfully!");
        }

        private static void AddPilot(AMSData amsData)
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Console.Write("Enter experience (years): ");
            int experience = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter flight hours: ");
            int flightHours = Convert.ToInt32(Console.ReadLine());

            // Pass all required arguments to Pilot constructor
            Pilot pilot = new Pilot(amsData.Astronauts.Count + 1, name, experience, flightHours);  // Assuming unique ID generation

            amsData.AddAstronaut(pilot); // Add Pilot object to AMSData
            Console.WriteLine("Pilot added successfully!");
        }

        private static void AddScientist(AMSData amsData)
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Console.Write("Enter experience (years): ");
            int experience = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter field of study: ");
            string fieldOfStudy = Console.ReadLine();

            // Pass all required arguments to Scientist constructor
            Scientist scientist = new Scientist(amsData.Astronauts.Count + 1, name, experience, fieldOfStudy);

            amsData.AddAstronaut(scientist); // Add Scientist object to AMSData
            Console.WriteLine("Scientist added successfully!");
        }

        private static void AddEngineer(AMSData amsData)
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Console.Write("Enter experience (years): ");
            int experience = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter specialization: ");
            string specialization = Console.ReadLine();

            // Generate unique ID (assuming you want one)
            int id = amsData.Astronauts.Count + 1; // Adjust for your ID generation logic

            Engineer engineer = new Engineer(id, name, experience, specialization);
            amsData.AddAstronaut(astronaut: engineer); // Pass engineer object
            Console.WriteLine("Engineer added successfully!");
        }

        public static void EditAstronaut(AMSData amsData)
        {
            Console.WriteLine("\nEdit Astronaut");
            Console.Write("Enter astronaut ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            if (!amsData.Astronauts.ContainsKey(id))
            {
                Console.WriteLine("Astronaut not found!");
                return;
            }

            Astronaut astronaut = amsData.Astronauts[id];

            Console.WriteLine($"Editing {astronaut.Name} ({astronaut.GetType().Name})");
            Console.WriteLine("1. Edit name");
            Console.WriteLine("2. Edit experience");
            Console.WriteLine("3. Back to Main Menu");

            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter new name: ");
                    astronaut.Name = Console.ReadLine();
                    break;
                case 2:
                    Console.Write("Enter new experience (years): ");
                    astronaut.Experience = Convert.ToInt32(Console.ReadLine());
                    break;
                case 3:
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }

            Console.WriteLine("Astronaut edited successfully!");
        }
        public static void ViewAstronauts(AMSData amsData)
        {
            Console.WriteLine("\nView Astronauts");

            if (!amsData.Astronauts.Any())
            {
                Console.WriteLine("No astronauts found!");
                return;
            }

            Console.WriteLine("List of Astronauts:");
            foreach (KeyValuePair<int, Astronaut> astronaut in amsData.Astronauts)
            {
                Console.WriteLine($"\tID: {astronaut.Key} - Name: {astronaut.Value.Name} - Type: {astronaut.Value.GetType().Name} - Experience: {astronaut.Value.Experience} years");
            }
        }


        public static void AddMission(AMSData amsData)
        {
            Console.WriteLine("\nAdd Mission");
            Console.Write("Enter mission name: ");
            string name = Console.ReadLine();

            Console.Write("Enter launch date (YYYY-MM-DD): ");
            DateTime launchDate = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Enter mission duration (days): ");
            int duration = Convert.ToInt32(Console.ReadLine());

            Mission mission = new Mission(amsData.Missions.Count + 1, name, launchDate, duration);
            amsData.Missions.Add(mission);
            Console.WriteLine("Mission added successfully!");
        }

        // Implement similar methods for EditMission, DeleteMission, ViewMissions

        public static void DeleteAstronaut(AMSData amsData)
        {
            Console.WriteLine("\nDelete Astronaut");
            Console.Write("Enter astronaut ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            if (!amsData.Astronauts.ContainsKey(id))
            {
                Console.WriteLine("Astronaut not found!");
                return;
            }

            Console.Write($"Are you sure you want to delete astronaut '{amsData.Astronauts[id].Name}' (y/n)? ");
            char confirmation = Convert.ToChar(Console.ReadLine().ToLower());

            if (confirmation == 'y')
            {
                amsData.Astronauts.Remove(id);
                Console.WriteLine("Astronaut deleted successfully!");
            }
            else
            {
                Console.WriteLine("Astronaut deletion canceled.");
            }
        }


        public static void EditMission(AMSData amsData)
        {
            Console.WriteLine("\nEdit Mission");
            Console.Write("Enter mission ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            if (!amsData.Missions.Any(m => m.Id == id))
            {
                Console.WriteLine("Mission not found!");
                return;
            }

            Mission mission = amsData.Missions.Find(m => m.Id == id);

            Console.WriteLine($"Editing mission: {mission.Name}");
            Console.WriteLine("1. Edit name");
            Console.WriteLine("2. Edit launch date");
            Console.WriteLine("3. Edit duration");
            Console.WriteLine("4. Back to Main Menu");

            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter new name: ");
                    mission.Name = Console.ReadLine();
                    break;
                case 2:
                    Console.Write("Enter new launch date (YYYY-MM-DD): ");
                    mission.LaunchDate = Convert.ToDateTime(Console.ReadLine());
                    break;
                case 3:
                    Console.Write("Enter new duration (days): ");
                    mission.Duration = Convert.ToInt32(Console.ReadLine());
                    break;
                case 4:
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }

            Console.WriteLine("Mission edited successfully!");
        }

        public static void DeleteMission(AMSData amsData)
        {
            Console.WriteLine("\nDelete Mission");
            Console.Write("Enter mission ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Mission mission = amsData.Missions.Find(m => m.Id == id);

            if (mission == null)
            {
                Console.WriteLine("Mission not found!");
                return;
            }

            Console.Write($"Are you sure you want to delete mission '{mission.Name}' (y/n)? ");
            char confirmation = Convert.ToChar(Console.ReadLine().ToLower());

            if (confirmation == 'y')
            {
                amsData.Missions.Remove(mission);
                Console.WriteLine("Mission deleted successfully!");
            }
            else
            {
                Console.WriteLine("Mission deletion canceled.");
            }
        }

    }

}