using Kursevi.Data.Models;

namespace Kursevi.Data.ViewModels
{
    public interface IPredavacEditor
    {
        Predavac Predavac { get; }

        void Save();
    }

    public class PredavacEditor : IPredavacEditor
    {
        public Predavac Predavac { get; set; } = new();

        private IPredavaciService PredavaciService { init; get; }

        public PredavacEditor(IPredavaciService predavaciService)
        {
            PredavaciService = predavaciService;
        }

        public void Save()
        {
            PredavaciService.SavePredavac(Predavac);
            Predavac = new();
        }
    }
}