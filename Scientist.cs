

namespace SpaceData
{
    public class Scientist : Astronaut
    {
        //public string FieldOfStudy { get; set; }

        public Scientist(int id, string name) : base(id, name, AstronautType.Scientist)
        {
            //FieldOfStudy = fieldOfStudy;
        }
    }

}