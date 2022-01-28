using Kursevi.Data.Models;

namespace Kursevi.Data
{
    public interface IKurseviServis
    {
        void SaveKurs(Kurs kurs);
    }

    public class KurseviServis : IKurseviServis
    {
        private ApplicationDbContext Db { init; get; }

        public KurseviServis(ApplicationDbContext db)
        {
            Db = db;
        }

        public void SaveKurs(Kurs kurs)
        {
            Db.Update(kurs);
            Db.SaveChanges();
        }
    }
}