using Kursevi.Data.Models;

namespace Kursevi.Data
{
    public interface IPredavaciService
    {
        Predavac? GetPredavac(int id);

        List<Predavac> GetAllPredavaci();
    }

    public class PredavaciService : IPredavaciService
    {
        private ApplicationDbContext Db { init; get; }

        public PredavaciService(ApplicationDbContext db)
        {
            Db = db;
        }

        public Predavac? GetPredavac(int id)
            => Db.Predavaci.Find(id);

        public List<Predavac> GetAllPredavaci()
            => Db.Predavaci.ToList();
    }
}