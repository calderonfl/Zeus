using System.Collections;
using System.Collections.Generic;

namespace Kadabra.Model.Stadium
{
    public class StadiumCollectionModel : ICollection<StadiumDisplayModel>
    {
        private readonly IList<StadiumDisplayModel> stadiums = null;

        public StadiumCollectionModel() : this(new List<StadiumDisplayModel>())
        {
        }
        public StadiumCollectionModel(IEnumerable<StadiumDisplayModel> stadiums)
        {
            this.stadiums = new List<StadiumDisplayModel>(stadiums);
        }

        public int Count => stadiums.Count;
        public bool IsReadOnly => stadiums.IsReadOnly;
        public void Add(StadiumDisplayModel item)
        {
            stadiums.Add(item);
        }

        public void Clear()
        {
            stadiums.Clear();
        }

        public bool Contains(StadiumDisplayModel item)
        {
            return stadiums.Contains(item);
        }

        public void CopyTo(StadiumDisplayModel[] array, int arrayIndex)
        {
            stadiums.CopyTo(array, arrayIndex);
        }

        public IEnumerator<StadiumDisplayModel> GetEnumerator()
        {
            return stadiums.GetEnumerator();
        }

        public bool Remove(StadiumDisplayModel item)
        {
            return stadiums.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return stadiums.GetEnumerator();
        }
    }
}
