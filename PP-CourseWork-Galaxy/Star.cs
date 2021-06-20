namespace PP_CourseWork_Galaxy
{
    class Star : SpaceUnit
    {
        public StarClass StarClass { get; }
        public int Temperature { get; }
        public float Luminosity { get; }
        public float Mass { get; }
        public float Size { get; }

        public Star(string name,int temperature, float luminosity, float mass, float size) : base(name)
        {
            Temperature = temperature;
            Luminosity = luminosity;
            Mass = mass;
            Size = size;
            StarClass = StarClass.ClassifyStarClass(this);
        }

        public override string Stats()
        {
            return string.Format(Constants.Messages.DETAILS_STAR, Name, StarClass != null ? StarClass.Name : Constants.Messages.NONE, Mass, Size, Temperature, Luminosity);
        }
    }
}