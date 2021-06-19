namespace PP_CourseWork_Galaxy
{
    class Star : SpaceUnit
    {
        public StarClass StarClass { get; }
        public int Temperature { get; }
        public float Luminosity { get; }
        public float Mass { get; }
        public float Radius { get; }

        public Star(string name,int temperature, float luminosity, float mass, float radius) : base(name)
        {
            Temperature = temperature;
            Luminosity = luminosity;
            Mass = mass;
            Radius = radius;
            StarClass = StarClass.ClassifyStarClass(this);
        }

        public override string Stats()
        {
            return string.Format(Constants.Messages.DETAILS_STAR, Name, StarClass.Name, Mass, Radius, Temperature, Luminosity);
        }
    }
}