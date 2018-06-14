using System.Collections;
using System.Collections.Generic;

namespace Kadabra.Model.Tournament
{
    public class TournamentCollectionModel : IEnumerable<TournamentDisplayModel>
    {
        private readonly IList<TournamentDisplayModel> stadiums = null;

        public TournamentCollectionModel() : this(new List<TournamentDisplayModel>())
        {
        }
        public TournamentCollectionModel(IEnumerable<TournamentDisplayModel> tournaments)
        {
            this.stadiums = new List<TournamentDisplayModel>(tournaments);
        }
        public IEnumerator<TournamentDisplayModel> GetEnumerator()
        {
            return stadiums.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return stadiums.GetEnumerator();
        }
    }
}
