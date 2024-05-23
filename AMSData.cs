namespace SpaceData
{
    public class AMSData
    {
        public Dictionary<int, Astronaut> Astronauts { get; set; }
        public List<Mission> Missions { get; set; }

        public AMSData()
        {
            Astronauts = new Dictionary<int, Astronaut>();
            Missions = new List<Mission>();
        }

        public void AddAstronaut(Astronaut astronaut)
        {

            int id;

            var idProperty = astronaut.GetType().GetProperty("Id");

            if (idProperty != null)
            {
                string idValue = idProperty.GetValue(astronaut) as string;
                if (int.TryParse(idValue, out id))
                {
                    id = Astronauts.Count + 1;
                    idProperty.SetValue(astronaut, id);
                }
                else
                {

                    Console.WriteLine("Error: Astronaut class 'Id' property value is not a valid integer.");
                    id = -1;
                }
            }
            else
            {
                Console.WriteLine("Error: Astronaut class does not have an 'Id' property.");
                id = -1;
            }


            if (id > 0)
            {
                Astronauts.Add(id, astronaut);
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

        public void DeleteAstronaut(int id)
        {
            if (Astronauts.ContainsKey(id))
            {
                Astronaut astronaut = Astronauts[id];
                Astronauts.Remove(id);

                // Potentially remove astronaut from missions (optional)
                // ... (code to remove astronaut from missions if applicable)

                Console.WriteLine($"Astronaut '{astronaut.Name}' (ID: {id}) deleted successfully!");
            }
            else
            {
                Console.WriteLine($"Astronaut with ID {id} not found!");
            }
        }
        public void ViewMissions(AMSData amsData)
        {
            if (amsData.Missions.Count == 0)
            {
                Console.WriteLine("There are no missions currently.");
                return;
            }

            Console.WriteLine("\nMissions:");
            Console.WriteLine("ID\tName\tDescription");
            Console.WriteLine("-------\t-------\t-----------");

            foreach (Mission mission in amsData.Missions)
            {
                Console.WriteLine($"{mission.Id}\t{mission.Name}\t{mission.Description}");
            }
        }

        public void ViewAstronauts()
        {
            if (Astronauts.Count == 0)
            {
                Console.WriteLine("No astronauts found!");
                return;
            }

            Console.WriteLine("\nAstronauts:");
            Console.WriteLine("ID\tName");
            Console.WriteLine("-------");

            foreach (KeyValuePair<int, Astronaut> astronautPair in Astronauts)
            {
                Astronaut astronaut = astronautPair.Value; // Access astronaut object
                Console.WriteLine($"{astronaut.Id}\t{astronaut.Name}");
            }
        }

    }
}
