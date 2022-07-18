namespace PcKonfigurator.Shared.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public string Jwt { get; set; }
    }
}
