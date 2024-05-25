namespace SpaceData
{

    public class Commander : Astronaut
    {
        //public int CommandMissions { get; set; }

        public Commander(int id, string name) : base(id, name, AstronautType.Commander)
        {
            //CommandMissions = commandMissions;
        }
    }

}