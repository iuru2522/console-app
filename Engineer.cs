
namespace SpaceData
{
    public class Engineer : Astronaut
    {
        public string Specialization { get; set; }

        public Engineer(int id, string name, int experience, string specialization) : base(id, name, experience, AstronautType.Engineer)
        {
            Specialization = specialization;
        }
    }


}