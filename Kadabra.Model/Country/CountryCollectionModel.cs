using System.Collections;
using System.Collections.Generic;

namespace Kadabra.Model.Country
{
    public class CountryCollectionModel : ICollection<CountryDisplayModel>
    {
        private readonly IList<CountryDisplayModel> teams = null;

        public CountryCollectionModel() : this(new List<CountryDisplayModel>())
        {
        }
        public CountryCollectionModel(IEnumerable<CountryDisplayModel> teamModels)
        {
            this.teams = new List<CountryDisplayModel>(teamModels);
        }

        public int Count => teams.Count;
        public bool IsReadOnly => teams.IsReadOnly;
        public void Add(CountryDisplayModel item)
        {
            teams.Add(item);
        }

        public void Clear()
        {
            teams.Clear();
        }

        public bool Contains(CountryDisplayModel item)
        {
            return teams.Contains(item);
        }

        public void CopyTo(CountryDisplayModel[] array, int arrayIndex)
        {
            teams.CopyTo(array, arrayIndex);
        }

        public IEnumerator<CountryDisplayModel> GetEnumerator()
        {
            return teams.GetEnumerator();
        }

        public bool Remove(CountryDisplayModel item)
        {
            return teams.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return teams.GetEnumerator();
        }
    }
}
