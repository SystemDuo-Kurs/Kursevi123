namespace Kursevi.Data.Models
{
    public class Kurs
    {
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;

        public TimeOnly? StartingTime
        {
            get => StartingTimeForDb.HasValue ? TimeOnly.FromTimeSpan(StartingTimeForDb.Value) : null;
            set => StartingTimeForDb = value.HasValue ? value.Value.ToTimeSpan() : null;
        }

        public TimeSpan? StartingTimeForDb { get; set; }

        public TimeOnly EndingTime =>
            StartingTime.Value.AddHours(LectureDuration.TotalHours);

        public DateOnly? StartingDate
        {
            get => StartingDateForDb.HasValue ?
                    DateOnly.FromDateTime(StartingDateForDb.Value) : null;
            set => StartingDateForDb = value.HasValue ? value.Value.ToDateTime(new TimeOnly())
                : null;
        }

        public DateTime? StartingDateForDb { get; set; }

        public DateOnly? EndingDate
        {
            get => EndingDateForDb.HasValue ?
                    DateOnly.FromDateTime(EndingDateForDb.Value) : null;
            set => EndingDateForDb = value.HasValue ? value.Value.ToDateTime(new TimeOnly())
                : null;
        }

        public DateTime? EndingDateForDb { get; set; }
        public TimeSpan LectureDuration { get; set; }
        public List<DoW> Days { get; set; } = new();
        public Predavac? Predavac { get; set; }
        public List<Polaznik> Polazniks { get; set; } = new();
    }
}