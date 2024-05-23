

namespace SpaceData
{
    public class Scientist : Astronaut
    {
        public string FieldOfStudy { get; set; }

        public Scientist(int id, string name, int experience, string fieldOfStudy) : base(id, name, experience, AstronautType.Scientist)
        {
            FieldOfStudy = fieldOfStudy;
        }
    }

}