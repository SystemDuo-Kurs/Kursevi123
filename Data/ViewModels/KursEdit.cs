using Kursevi.Data.Models;

namespace Kursevi.Data.ViewModels
{
    public interface IKursEdit
    {
        Kurs Kurs { get; set; }
        DateTime? Pocetak { get; set; }
        DateTime? Kraj { get; set; }

        void Save();
    }

    public class KursEdit : IKursEdit
    {
        public Kurs Kurs { get; set; } = new();

        public DateTime? Pocetak
        {
            get => Kurs.StartingDate.ToDateTime(new TimeOnly());
            set => Kurs.StartingDate = DateOnly.FromDateTime(value.Value);
        }

        public DateTime? Kraj
        {
            get => Kurs.EndingDate.ToDateTime(new TimeOnly());
            set => Kurs.EndingDate = DateOnly.FromDateTime(value.Value);
        }

        private IKurseviServis KurseviServis { init; get; }

        public KursEdit(IKurseviServis kurseviServis)
        {
            KurseviServis = kurseviServis;
        }

        public void Save()
        {
            KurseviServis.SaveKurs(Kurs);
            Kurs = new();
        }
    }
}