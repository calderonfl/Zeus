﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Kadabra.Model.Country.Services;
using Kadabra.Model.Country;
using Kadabra.Data;
using Kadabra.Data.Identity;

namespace Kadabra.Api.Servicios
{
    internal class CountryServices : ICountryServices
    {
        private bool disposedValue = false;
        private readonly IRepository<KadabraCountry> repository;

        public CountryServices(IRepository<KadabraCountry> repository)
        {
            this.repository = repository;
        }
        public async Task Add(CountryAddModel Country)
        {
            await repository.Add(new KadabraCountry()
            {
                ImageFlag = Country.ImageFlag,
                Name = Country.Name,
                CountryKey = Country.CountryKey,
                Id = Guid.NewGuid().ToString()
            });
            await repository.Save();
        }
        public async Task Edit(CountryModel country)
        {
            await repository.Update(new KadabraCountry()
            {
                Id = country.Id,
                ImageFlag = country.ImageFlag,
                Name = country.Name,
                CountryKey = country.CountryKey
            });
            await repository.Save();
        }
        public async Task<CountryCollectionModel> GetAllCountries()
        {
            var entities = await repository.GetAll();
            var countries = entities.Select(country => new CountryDisplayModel()
            {
                Id = country.Id,
                Name = country.Name,
                CountryKey = country.CountryKey
            });
            return new CountryCollectionModel(countries);
        }
        public async Task Remove(CountryIdModel Country)
        {
            await repository.Delete(t => t.Id == Country.Id);
            await repository.Save();
        }
        public async Task<CountryModel> GetCountry(CountryIdModel model)
        {
            KadabraCountry Country = await repository.FindOne(f => f.Id == model.Id);
            return new CountryModel()
            {
                Id = Country.Id,
                ImageFlag = Country.ImageFlag,
                Name = Country.Name,
                CountryKey = Country.CountryKey
            };
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
        ~CountryServices()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}