

namespace SpaceData
{


    public class Mission
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime LaunchDate { get; set; }
        public int Duration { get; set; } // In days
        public List<Astronaut> AssignedAstronauts { get; set; }
           public string Description { get; set; }

        public Mission(int id, string name, DateTime launchDate, int duration, string description = "")
        {
            Id = id;
            Name = name;
            LaunchDate = launchDate;
            Duration = duration;
            AssignedAstronauts = new List<Astronaut>();
            Description = description;
        }
    }

}