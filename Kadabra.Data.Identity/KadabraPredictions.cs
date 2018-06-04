using System.Collections;
using System.Collections.Generic;

namespace Kadabra.Data.Identity
{
    public class KadabraPredictions : ICollection<KadabraPrediction>
    {
        private readonly IList<KadabraPrediction> predictions;

        public KadabraPredictions()
        {
            predictions = new List<KadabraPrediction>();
        }

        int ICollection<KadabraPrediction>.Count => predictions.Count;

        bool ICollection<KadabraPrediction>.IsReadOnly => predictions.IsReadOnly;

        public void Add(KadabraPrediction item)
        {
            predictions.Add(item);
        }

        void ICollection<KadabraPrediction>.Clear()
        {
            predictions.Clear();
        }

        bool ICollection<KadabraPrediction>.Contains(KadabraPrediction item)
        {
            return predictions.Contains(item);
        }

        void ICollection<KadabraPrediction>.CopyTo(KadabraPrediction[] array, int arrayIndex)
        {
            predictions.CopyTo(array, arrayIndex);
        }

        IEnumerator<KadabraPrediction> IEnumerable<KadabraPrediction>.GetEnumerator()
        {
            return predictions.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return predictions.GetEnumerator();
        }

        bool ICollection<KadabraPrediction>.Remove(KadabraPrediction item)
        {
            return predictions.Remove(item);
        }
    
    }
}