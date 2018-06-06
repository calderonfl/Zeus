using System.Collections;
using System.Collections.Generic;

namespace Kadabra.Data.Identity
{
    public class KadabraUsers : ICollection<KadabraUser>
    {
        private readonly IList<KadabraUser> userTournaments;

        public KadabraUsers()
        {
            userTournaments = new List<KadabraUser>();
        }

        public int Count => userTournaments.Count;

        bool ICollection<KadabraUser>.IsReadOnly => userTournaments.IsReadOnly;

        void ICollection<KadabraUser>.Add(KadabraUser item)
        {
            userTournaments.Add(item);
        }

        void ICollection<KadabraUser>.Clear()
        {
            userTournaments.Clear();
        }

        bool ICollection<KadabraUser>.Contains(KadabraUser item)
        {
            return userTournaments.Contains(item);
        }

        void ICollection<KadabraUser>.CopyTo(KadabraUser[] array, int arrayIndex)
        {
            userTournaments.CopyTo(array, arrayIndex);
        }

        IEnumerator<KadabraUser> IEnumerable<KadabraUser>.GetEnumerator()
        {
            return userTournaments.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return userTournaments.GetEnumerator();
        }

        bool ICollection<KadabraUser>.Remove(KadabraUser item)
        {
            return userTournaments.Remove(item);
        }
    
    }
}