using Kursevi.Data.Models;

namespace Kursevi.Data
{
    public interface IKurseviServis
    {
        Task SaveKurs(Kurs kurs);
    }

    public class KurseviServis : IKurseviServis
    {
        private ApplicationDbContext Db { init; get; }

        public KurseviServis(ApplicationDbContext db)
        {
            Db = db;
        }

        public async Task SaveKurs(Kurs kurs)
        {
            Db.Update(kurs);
            await Db.SaveChangesAsync();
        }
    }
}