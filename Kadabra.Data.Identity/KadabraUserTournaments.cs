using System.Collections;
using System.Collections.Generic;

namespace Kadabra.Data.Identity
{
    public class KadabraUserTournaments : ICollection<KadabraUserTournament>
    {
        private readonly IList<KadabraUserTournament> userTournaments;

        public KadabraUserTournaments() 
        {
            userTournaments = new List<KadabraUserTournament>();
        }

        int ICollection<KadabraUserTournament>.Count => userTournaments.Count;

        bool ICollection<KadabraUserTournament>.IsReadOnly => userTournaments.IsReadOnly;

        void ICollection<KadabraUserTournament>.Add(KadabraUserTournament item)
        {
            userTournaments.Add(item);
        }

        void ICollection<KadabraUserTournament>.Clear()
        {
            userTournaments.Clear();
        }

        bool ICollection<KadabraUserTournament>.Contains(KadabraUserTournament item)
        {
            return userTournaments.Contains(item);
        }

        void ICollection<KadabraUserTournament>.CopyTo(KadabraUserTournament[] array, int arrayIndex)
        {
            userTournaments.CopyTo(array, arrayIndex);
        }

        IEnumerator<KadabraUserTournament> IEnumerable<KadabraUserTournament>.GetEnumerator()
        {
            return userTournaments.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return userTournaments.GetEnumerator();
        }

        bool ICollection<KadabraUserTournament>.Remove(KadabraUserTournament item)
        {
           return userTournaments.Remove(item);
        }
    }
}