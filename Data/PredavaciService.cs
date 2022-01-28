using Kursevi.Data.Models;

namespace Kursevi.Data
{
    public interface IPredavaciService
    {
        Predavac? GetPredavac(int id);

        List<Predavac> GetAllPredavaci();

        void SavePredavac(Predavac p);

        void ObrisiPredavaca(Predavac p);
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

        public void ObrisiPredavaca(Predavac p)
        {
            Db.Remove(p);
            Db.SaveChanges();
        }

        public void SavePredavac(Predavac p)
        {
            Db.Update(p);
            Db.SaveChanges();
        }
    }
}