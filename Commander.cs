

namespace SpaceData
{

    public class Commander : Astronaut
    {
        public int CommandMissions { get; set; }

        public Commander(int id, string name, int experience, int commandMissions) : base(id, name, experience, AstronautType.Commander)
        {
            CommandMissions = commandMissions;
        }
    }

}