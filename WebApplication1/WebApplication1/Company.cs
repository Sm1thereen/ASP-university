namespace WebApplication1
{
    public class Company
    {
        public string Name { get; set; }
        public string Industry { get; set; }
        public int YearFounded { get; set; }

        public Company(string name, string industry, int yearFounded)
        {
            Name = name;
            Industry = industry;
            YearFounded = yearFounded;
        }
    }
}