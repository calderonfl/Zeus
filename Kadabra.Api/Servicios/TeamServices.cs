﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Kadabra.Model.Team.Services;
using Kadabra.Model.Team;
using Kadabra.Data;
using Kadabra.Data.Identity;
using Kadabra.Model.Country;
using System.Data.Entity;

namespace Kadabra.Api.Servicios
{
    internal class TeamServices : ITeamServices
    {
        private bool disposedValue = false;
        private readonly IRepository<KadabraTeam> repository;

        public TeamServices(IRepository<KadabraTeam> repository)
        {
            this.repository = repository;
        }
        public async Task Add(TeamAddModel team)
        {
            await repository.Add(new KadabraTeam()
            {
                CountryId = team.Country,
                ImageFlag = team.ImageFlag,
                Name = team.Name,
                TeamKey = team.TeamKey,
                Id= Guid.NewGuid().ToString()
            });
            await repository.Save();
        }
        public async Task Edit(TeamModel team)
        {
            await repository.Update(new KadabraTeam()
            {
                Id= team.Id,
                CountryId = team.Country,
                ImageFlag = team.ImageFlag,
                Name = team.Name,
                TeamKey = team.TeamKey
            });
            await repository.Save();
        }
        public async Task<TeamCollectionModel> GetAll()
        {
            var entities = (await repository.GetQuery()).Include<KadabraTeam, KadabraCountry>(f => f.Country);
            var teams = entities.Select(team => new TeamModel()
            {
                Id = team.Id,
                Country = team.Country.Name,
                ImageFlag = team.ImageFlag,
                Name = team.Name,
                TeamKey = team.TeamKey
            });
            return new TeamCollectionModel(teams);
        }
        public async Task Remove(TeamIdModel team)
        {
            await repository.Delete(t => t.Id == team.Id);
            await repository.Save();
        }
        public async Task<TeamModel> Get(TeamIdModel model)
        {
            KadabraTeam team = await repository.FindOne(f => f.Id == model.Id);
            return new TeamModel()
            {
                Country = team.Country.Name,
                Id = team.Id,
                ImageFlag = team.ImageFlag,
                Name = team.Name,
                TeamKey = team.TeamKey
            };
        }
        public async Task<CountryCollectionModel> GetAllCountries()
        {
            return await new CountryServices(new RepositoryCountry()).GetAllCountries();
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
        ~TeamServices()
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