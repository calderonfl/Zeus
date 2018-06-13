using System;
using System.Threading.Tasks;

namespace Kadabra.Model.Stadium.Services
{
    public interface IStadiumServices : IDisposable
    {
        Task Edit(StadiumModel stadium);
        Task Remove(StadiumIdModel stadium);
        Task Add(StadiumAddModel stadium);
        Task<StadiumCollectionModel> GetAllStadiums();
        Task<StadiumModel> GetStadium(StadiumIdModel stadium);
    }
}
