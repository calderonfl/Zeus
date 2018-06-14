using Kadabra.Data;
using Kadabra.Data.Identity;
using Kadabra.Model.Country;
using Kadabra.Model.Country.Services;
using Kadabra.Model.Stadium;
using Kadabra.Model.Stadium.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Kadabra.Api.Servicios
{
    internal class StadiumServices : IStadiumServices
    {
        private bool disposedValue = false;
        private readonly IRepository<KadabraStadium> repository;
        private readonly ICountryServices services;


        public StadiumServices(IRepository<KadabraStadium> repository)
        {
            this.repository = repository;
            services = new CountryServices(new RepositoryCountry());
        }
        public async Task Add(StadiumAddModel stadium)
        {
            await repository.Add(new KadabraStadium()
            {
                Description = stadium.Description,
                Name = stadium.Name,
                Capacity = stadium.Capacity,
                CountryId = stadium.CountryId,
                Id = Guid.NewGuid().ToString()
            });
            await repository.Save();
        }

        public async Task Edit(StadiumModel stadium)
        {
            await repository.Update(new KadabraStadium()
            {
                Id = stadium.Id,
                Description = stadium.Description,
                Name = stadium.Name,
                CountryId = stadium.CountryId,
                Capacity = stadium.Capacity
            });
            await repository.Save();
        }

        public async Task<StadiumCollectionModel> GetAllStadiums()
        {
            var entities = await repository.GetAll();
            var stadiums = entities.Select(stadium => new StadiumDisplayModel()
            {
                Id = stadium.Id,
                Description = stadium.Description,
                Name = stadium.Name,
                Country = stadium.Country.Name,
                Capacity = stadium.Capacity
            });
            return new StadiumCollectionModel(stadiums);
        }

        public async Task<StadiumModel> GetStadium(StadiumIdModel stadium)
        {
            KadabraStadium currentStadium = await repository.FindOne(f => f.Id == stadium.Id);
            return new StadiumModel()
            {
                Id = currentStadium.Id,
                Description = currentStadium.Description,
                Name = currentStadium.Name,
                CountryId = currentStadium.CountryId,
                Capacity = currentStadium.Capacity
            };
        }

        public async Task Remove(StadiumIdModel stadium)
        {
            await repository.Delete(t => t.Id == stadium.Id);
            await repository.Save();
        }
        protected void Dispose(bool disposing)
        {
            if (disposedValue)
            {
                if (disposing)
                {

                }
            }
        }
        ~StadiumServices()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public async Task<StadiumModelWithCountries> GetStadiumWithCountries()
        {
            return await GetStadiumWithCountries(null);
        }
        public async Task<StadiumModelWithCountries> GetStadiumWithCountries(StadiumIdModel stadium)
        {
            var countries = await services.GetAllCountries();
            return await GetStadiumWithCountries(stadium, countries);
        }

        private async Task<StadiumModelWithCountries> GetStadiumWithCountries(StadiumIdModel stadium, CountryCollectionModel countries)
        {
            if (stadium == null) return new StadiumModelWithCountries(countries);
            else
            {
                var model = await this.GetStadium(stadium);
                return new StadiumModelWithCountries(model, countries);
            }
        }
    }
}