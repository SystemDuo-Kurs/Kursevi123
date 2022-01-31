using Kursevi.Data.Models;

namespace Kursevi.Data.ViewModels
{
    public interface IKursEdit
    {
        Kurs Kurs { get; set; }
        int Minuta { get; set; }
        int Sati { get; set; }

        Task Save();
    }

    public class KursEdit : IKursEdit
    {
        public Kurs Kurs { get; set; } = new();

        private int _sati;

        public int Sati
        {
            get => _sati;
            set
            {
                _sati = value;
                Kurs.LectureDuration = new TimeSpan(Sati, Minuta, 0);
            }
        }

        private int _minuta;

        public int Minuta
        {
            get => _minuta;
            set
            {
                _minuta = value;
                Kurs.LectureDuration = new TimeSpan(Sati, Minuta, 0);
            }
        }

        private IKurseviServis KurseviServis { init; get; }

        public KursEdit(IKurseviServis kurseviServis)
        {
            KurseviServis = kurseviServis;
        }

        public async Task Save()
        {
            await KurseviServis.SaveKurs(Kurs);
            Kurs = new();
        }
    }
}