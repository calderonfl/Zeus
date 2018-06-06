using System.Collections;
using System.Collections.Generic;

namespace Kadabra.Data.Identity
{
    public class KadabraTournaments : ICollection<KadabraTournament>
    {
        private readonly IList<KadabraTournament> userTournaments;

        public KadabraTournaments()
        {
            userTournaments = new List<KadabraTournament>();
        }

        int ICollection<KadabraTournament>.Count => userTournaments.Count;

        bool ICollection<KadabraTournament>.IsReadOnly => userTournaments.IsReadOnly;

        void ICollection<KadabraTournament>.Add(KadabraTournament item)
        {
            userTournaments.Add(item);
        }

        void ICollection<KadabraTournament>.Clear()
        {
            userTournaments.Clear();
        }

        bool ICollection<KadabraTournament>.Contains(KadabraTournament item)
        {
            return userTournaments.Contains(item);
        }

        void ICollection<KadabraTournament>.CopyTo(KadabraTournament[] array, int arrayIndex)
        {
            userTournaments.CopyTo(array, arrayIndex);
        }

        IEnumerator<KadabraTournament> IEnumerable<KadabraTournament>.GetEnumerator()
        {
            return userTournaments.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return userTournaments.GetEnumerator();
        }

        bool ICollection<KadabraTournament>.Remove(KadabraTournament item)
        {
            return userTournaments.Remove(item);
        }
    
    }
}