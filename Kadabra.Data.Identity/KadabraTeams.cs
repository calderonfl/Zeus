using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kadabra.Data.Identity
{
    public class KadabraTeams : ICollection<KadabraTeam>
    {
        private readonly IList<KadabraTeam> leagues;

        public KadabraTeams()
        {
            leagues = new List<KadabraTeam>();
        }

        int ICollection<KadabraTeam>.Count => leagues.Count;

        bool ICollection<KadabraTeam>.IsReadOnly => leagues.IsReadOnly;

        void ICollection<KadabraTeam>.Add(KadabraTeam item)
        {
            leagues.Add(item);
        }

        void ICollection<KadabraTeam>.Clear()
        {
            leagues.Clear();
        }

        bool ICollection<KadabraTeam>.Contains(KadabraTeam item)
        {
            return leagues.Contains(item);
        }

        void ICollection<KadabraTeam>.CopyTo(KadabraTeam[] array, int arrayIndex)
        {
            leagues.CopyTo(array, arrayIndex);
        }

        IEnumerator<KadabraTeam> IEnumerable<KadabraTeam>.GetEnumerator()
        {
            return leagues.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return leagues.GetEnumerator();
        }

        bool ICollection<KadabraTeam>.Remove(KadabraTeam item)
        {
            return leagues.Remove(item);
        }
    }
}
