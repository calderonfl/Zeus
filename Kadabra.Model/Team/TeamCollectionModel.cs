using System.Collections;
using System.Collections.Generic;

namespace Kadabra.Model.Team
{
    public class TeamCollectionModel : ICollection<TeamModel>
    {
        private readonly IList<TeamModel> teams = null;

        public TeamCollectionModel(IEnumerable<TeamModel> teamModels)
        {
            this.teams = new List<TeamModel>(teamModels);
        }

        public int Count => teams.Count;
        public bool IsReadOnly => teams.IsReadOnly;
        public void Add(TeamModel item)
        {
            teams.Add(item);
        }

        public void Clear()
        {
            teams.Clear();
        }

        public bool Contains(TeamModel item)
        {
            return teams.Contains(item);
        }

        public void CopyTo(TeamModel[] array, int arrayIndex)
        {
            teams.CopyTo(array, arrayIndex);
        }

        public IEnumerator<TeamModel> GetEnumerator()
        {
            return teams.GetEnumerator();
        }

        public bool Remove(TeamModel item)
        {
            return teams.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return teams.GetEnumerator();
        }
    }
}
