using Kursevi.Data.Models;
using System.Collections.ObjectModel;

namespace Kursevi.Data.ViewModels
{
    public interface IListaPredavaca
    {
        ObservableCollection<Predavac> Predavaci { get; }

        void GetAll();
    }

    public class ListaPredavaca : IListaPredavaca
    {
        public ObservableCollection<Predavac> Predavaci { get; private set; }
            = new();

        private IPredavaciService PredavaciService { get; init; }

        public ListaPredavaca(IPredavaciService predavaciService)
        {
            PredavaciService = predavaciService;
            GetAll();
        }

        public void GetAll()
        {
            Predavaci.Clear();
            PredavaciService.GetAllPredavaci()
                .ForEach(p => Predavaci.Add(p));
        }
    }
}