using Kursevi.Data.Models;
using System.Collections.ObjectModel;

namespace Kursevi.Data.ViewModels
{
    public interface IListaPredavaca
    {
        public ObservableCollection<Predavac> Predavaci { get; }
    }

    public class ListaPredavaca : IListaPredavaca
    {
        public ObservableCollection<Predavac> Predavaci { get; private set; }
            = new();

        public ListaPredavaca(IPredavaciService predavaciService)
        {
            predavaciService.GetAllPredavaci()
                .ForEach(p => Predavaci.Add(p));
        }
    }
}