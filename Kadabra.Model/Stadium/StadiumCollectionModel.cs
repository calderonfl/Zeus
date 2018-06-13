using System.Collections;
using System.Collections.Generic;

namespace Kadabra.Model.Stadium
{
    public class StadiumCollectionModel : ICollection<StadiumModel>
    {
        private readonly IList<StadiumModel> stadiums = null;

        public StadiumCollectionModel() : this(new List<StadiumModel>())
        {
        }
        public StadiumCollectionModel(IEnumerable<StadiumModel> teamModels)
        {
            this.stadiums = new List<StadiumModel>(teamModels);
        }

        public int Count => stadiums.Count;
        public bool IsReadOnly => stadiums.IsReadOnly;
        public void Add(StadiumModel item)
        {
            stadiums.Add(item);
        }

        public void Clear()
        {
            stadiums.Clear();
        }

        public bool Contains(StadiumModel item)
        {
            return stadiums.Contains(item);
        }

        public void CopyTo(StadiumModel[] array, int arrayIndex)
        {
            stadiums.CopyTo(array, arrayIndex);
        }

        public IEnumerator<StadiumModel> GetEnumerator()
        {
            return stadiums.GetEnumerator();
        }

        public bool Remove(StadiumModel item)
        {
            return stadiums.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return stadiums.GetEnumerator();
        }
    }
}
