using System.Collections;
using System.Collections.Generic;

namespace Kadabra.Data.Identity
{
    public class KadabraStadiums : ICollection<KadabraStadium>
    {
        private readonly IList<KadabraStadium> userTournaments;

        public KadabraStadiums()
        {
            userTournaments = new List<KadabraStadium>();
        }

        int ICollection<KadabraStadium>.Count => userTournaments.Count;

        bool ICollection<KadabraStadium>.IsReadOnly => userTournaments.IsReadOnly;

        void ICollection<KadabraStadium>.Add(KadabraStadium item)
        {
            userTournaments.Add(item);
        }

        void ICollection<KadabraStadium>.Clear()
        {
            userTournaments.Clear();
        }

        bool ICollection<KadabraStadium>.Contains(KadabraStadium item)
        {
            return userTournaments.Contains(item);
        }

        void ICollection<KadabraStadium>.CopyTo(KadabraStadium[] array, int arrayIndex)
        {
            userTournaments.CopyTo(array, arrayIndex);
        }

        IEnumerator<KadabraStadium> IEnumerable<KadabraStadium>.GetEnumerator()
        {
            return userTournaments.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return userTournaments.GetEnumerator();
        }

        bool ICollection<KadabraStadium>.Remove(KadabraStadium item)
        {
            return userTournaments.Remove(item);
        }
    }
}