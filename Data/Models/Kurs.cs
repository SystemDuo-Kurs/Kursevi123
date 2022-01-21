namespace Kursevi.Data.Models
{
    public class Kurs
    {
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;

        public TimeOnly StartingTime
        {
            get => TimeOnly.Parse(StartingTimeForDb);
            set => StartingTimeForDb = value.ToString();
        }

        private string StartingTimeForDb { get; set; } = string.Empty;
        public TimeSpan Duration { get; set; }
        public List<DoW> Days { get; set; } = new();

        public Predavac? Predavac { get; set; }
        public List<Polaznik> Polazniks { get; set; } = new();
    }
}