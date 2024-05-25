namespace SpaceData
{
    public class Engineer : Astronaut
    {
        //public string Specialization { get; set; }

        public Engineer(int id, string name) : base (id, name, AstronautType.Engineer)
        {
            //Specialization = specialization;
        }
    }


}