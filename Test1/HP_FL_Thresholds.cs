using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    class HP_FL_Thresholds
    {
        public List<Tuple<subdata, subdata>> thresholds_subdata;

        public HP_FL_Thresholds()
        {
            thresholds_subdata = new List<Tuple<subdata, subdata>>();
        }

        public void Add_tracked_threshold (Tuple <subdata,subdata> in_tuple)
        {
            thresholds_subdata.Add(in_tuple);
        }
    }
}
