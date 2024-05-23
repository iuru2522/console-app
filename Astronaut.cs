namespace SpaceData
{

    public enum AstronautType { Commander, Pilot, Scientist, Engineer }

    public abstract class Astronaut
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Experience { get; set; }
        public AstronautType Type { get; set; }


        public Astronaut(int id, string name, int experience, AstronautType type)
        {
            Id = id;
            Name = name;
            Experience = experience;
            Type = type;
        }
    }

}