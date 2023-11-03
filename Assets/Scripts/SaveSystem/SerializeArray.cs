using System.Collections.Generic;
using System.Linq;

namespace SaveSystem
{
    [System.Serializable]
    public class SerializeArray<T> where T : ISave
    {
        public T[] SavedData;

        public SerializeArray(IEnumerable<T> data)
        {
            SavedData = data.ToArray();
        }
    }
}