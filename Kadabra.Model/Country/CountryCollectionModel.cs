using System.Collections;
using System.Collections.Generic;

namespace Kadabra.Model.Country
{
    public class CountryCollectionModel : ICollection<CountryModel>
    {
        private readonly IList<CountryModel> teams = null;

        public CountryCollectionModel() : this(new List<CountryModel>())
        {
        }
        public CountryCollectionModel(IEnumerable<CountryModel> teamModels)
        {
            this.teams = new List<CountryModel>(teamModels);
        }

        public int Count => teams.Count;
        public bool IsReadOnly => teams.IsReadOnly;
        public void Add(CountryModel item)
        {
            teams.Add(item);
        }

        public void Clear()
        {
            teams.Clear();
        }

        public bool Contains(CountryModel item)
        {
            return teams.Contains(item);
        }

        public void CopyTo(CountryModel[] array, int arrayIndex)
        {
            teams.CopyTo(array, arrayIndex);
        }

        public IEnumerator<CountryModel> GetEnumerator()
        {
            return teams.GetEnumerator();
        }

        public bool Remove(CountryModel item)
        {
            return teams.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return teams.GetEnumerator();
        }
    }
}
