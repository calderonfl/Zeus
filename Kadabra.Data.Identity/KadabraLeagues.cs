using System.Collections;
using System.Collections.Generic;

namespace Kadabra.Data.Identity
{
    public class KadabraLeagues : ICollection<KadabraLeague>
    {
        private readonly IList<KadabraLeague> leagues;

        public KadabraLeagues()
        {
            leagues = new List<KadabraLeague>();
        }

        int ICollection<KadabraLeague>.Count => leagues.Count;

        bool ICollection<KadabraLeague>.IsReadOnly => leagues.IsReadOnly;

        void ICollection<KadabraLeague>.Add(KadabraLeague item)
        {
            leagues.Add(item);
        }

        void ICollection<KadabraLeague>.Clear()
        {
            leagues.Clear();
        }

        bool ICollection<KadabraLeague>.Contains(KadabraLeague item)
        {
            return leagues.Contains(item);
        }

        void ICollection<KadabraLeague>.CopyTo(KadabraLeague[] array, int arrayIndex)
        {
            leagues.CopyTo(array, arrayIndex);
        }

        IEnumerator<KadabraLeague> IEnumerable<KadabraLeague>.GetEnumerator()
        {
            return leagues.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return leagues.GetEnumerator();
        }

        bool ICollection<KadabraLeague>.Remove(KadabraLeague item)
        {
            return leagues.Remove(item);
        }
    }
}
