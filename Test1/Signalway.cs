using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    public class Signalway: IEnumerable<DataPair>
    {
        public ICollection<DataPair> pairs;

        
        public Signalway()
        {
            pairs = new List<DataPair>();
        }

        public IEnumerator<DataPair> GetEnumerator()
        {
            return pairs.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
           return this.GetEnumerator();
        }
    }
}
