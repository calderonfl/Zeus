using System.Collections;
using System.Collections.Generic;

namespace Kadabra.Model.Team
{
    public class TeamCollectionModel : ICollection<TeamDisplayModel>
    {
        private readonly IList<TeamDisplayModel> teams = null;

        public TeamCollectionModel() : this(new List<TeamDisplayModel>())
        {
        }
        public TeamCollectionModel(IEnumerable<TeamDisplayModel> TeamDisplayModels)
        {
            this.teams = new List<TeamDisplayModel>(TeamDisplayModels);
        }

        public int Count => teams.Count;
        public bool IsReadOnly => teams.IsReadOnly;
        public void Add(TeamDisplayModel item)
        {
            teams.Add(item);
        }

        public void Clear()
        {
            teams.Clear();
        }

        public bool Contains(TeamDisplayModel item)
        {
            return teams.Contains(item);
        }

        public void CopyTo(TeamDisplayModel[] array, int arrayIndex)
        {
            teams.CopyTo(array, arrayIndex);
        }

        public IEnumerator<TeamDisplayModel> GetEnumerator()
        {
            return teams.GetEnumerator();
        }

        public bool Remove(TeamDisplayModel item)
        {
            return teams.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return teams.GetEnumerator();
        }
    }
}
