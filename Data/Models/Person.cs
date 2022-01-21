namespace Kursevi.Data.Models
{
    public abstract class Person
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public List<Kurs> Courses { get; set; } = new();
    }
}