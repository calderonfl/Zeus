using Kadabra.Data;
using Kadabra.Data.Identity;
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

        public StadiumServices(IRepository<KadabraStadium> repository)
        {
            this.repository = repository;
        }
        public async Task Add(StadiumAddModel stadium)
        {
            await repository.Add(new KadabraStadium()
            {
                Description = stadium.Description,
                Name = stadium.Name,
                Capacity = stadium.Capacity,
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
                Capacity = stadium.Capacity
            });
            await repository.Save();
        }

        public async Task<StadiumCollectionModel> GetAllStadiums()
        {
            var entities = await repository.GetAll();
            var stadiums = entities.Select(stadium => new StadiumModel()
            {
                Id = stadium.Id,
                Description = stadium.Description,
                Name = stadium.Name,
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
    }
}