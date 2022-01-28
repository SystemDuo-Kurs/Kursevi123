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

        public TimeOnly EndingTime =>
            StartingTime.AddHours(LectureDuration.TotalHours);

        public DateOnly StartingDate
        {
            get
            {
                if (DateOnly.TryParse(StartingDateForDb, out DateOnly date))
                    return date;
                else
                    return new DateOnly();
            }
            set => StartingDateForDb = value.ToString();
        }

        public DateOnly EndingDate
        {
            get
            {
                if (DateOnly.TryParse(EndingDateForDb, out DateOnly date))
                    return date;
                else
                    return new DateOnly();
            }
            set => EndingDateForDb = value.ToString();
        }

        public string StartingDateForDb { get; set; } = string.Empty;
        public string EndingDateForDb { get; set; } = string.Empty;
        public string StartingTimeForDb { get; set; } = string.Empty;
        public TimeSpan LectureDuration { get; set; }
        public TimeSpan CourseDuration { get; set; }
        public List<DoW> Days { get; set; } = new();

        public Predavac? Predavac { get; set; }
        public List<Polaznik> Polazniks { get; set; } = new();
    }
}