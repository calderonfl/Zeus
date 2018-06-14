using System.Threading.Tasks;

namespace Kadabra.Model.Tournament
{
    public interface ITournamentServices
    {
        Task<TournamentCollectionModel> GetAllTournaments();
    }
}
