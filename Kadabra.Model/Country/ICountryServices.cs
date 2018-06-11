using System;
using System.Threading.Tasks;

namespace Kadabra.Model.Country.Services
{
    public interface ICountryServices : IDisposable
    {
        Task Edit(CountryModel team);
        Task Remove(CountryIdModel team);
        Task Add(CountryAddModel team);
        Task<CountryCollectionModel> GetAllCountries();
        Task<CountryModel> GetCountry(CountryIdModel model);
    }
}
