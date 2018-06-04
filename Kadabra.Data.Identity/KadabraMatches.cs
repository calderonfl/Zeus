using System;
using System.Collections;
using System.Collections.Generic;

namespace Kadabra.Data.Identity
{
    public class KadabraMatches : ICollection<KadabraMatch>
    {
        private readonly IList<KadabraMatch> matches;

        public KadabraMatches()
        {
            matches = new List<KadabraMatch>();
        }

        int ICollection<KadabraMatch>.Count => matches.Count;

        bool ICollection<KadabraMatch>.IsReadOnly => matches.IsReadOnly;

        public void Add(KadabraMatch item)
        {
            matches.Add(item);
        }

        void ICollection<KadabraMatch>.Clear()
        {
            matches.Clear();
        }

        bool ICollection<KadabraMatch>.Contains(KadabraMatch item)
        {
            return matches.Contains(item);
        }

        void ICollection<KadabraMatch>.CopyTo(KadabraMatch[] array, int arrayIndex)
        {
            matches.CopyTo(array, arrayIndex);
        }

        IEnumerator<KadabraMatch> IEnumerable<KadabraMatch>.GetEnumerator()
        {
            return matches.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return matches.GetEnumerator();
        }

        bool ICollection<KadabraMatch>.Remove(KadabraMatch item)
        {
            return matches.Remove(item);
        }
    }
}