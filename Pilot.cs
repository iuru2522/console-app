
namespace SpaceData
{

    public class Pilot : Astronaut
    {
        public int FlightHours { get; set; }

        public Pilot(int id, string name, int experience, int flightHours) : base(id, name, experience, AstronautType.Pilot)
        {
            FlightHours = flightHours;
        }
    }

}