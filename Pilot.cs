namespace SpaceData
{

    public class Pilot : Astronaut
    {
        //public int FlightHours { get; set; }

        public Pilot(int id, string name) : base(id, name, AstronautType.Pilot)
        {
            //FlightHours = flightHours;
        }
    }

}