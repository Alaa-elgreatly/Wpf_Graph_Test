using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using LiveCharts.Defaults;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Test1
{
    public class MyObservablePoint : INotifyPropertyChanged /*: ObservablePoint*/
    {
        private int _index;
        public subdata MyThreshold;

        public event PropertyChangedEventHandler PropertyChanged;

        public MyObservablePoint(int Index, subdata mysub)
        {
            MyThreshold = mysub;
            _index = Index;

        }
        public  double X
        {
            get
            {
                return subdata.Distances[_index];

            }

            private set
            {
                ;
            }
        }

        public  double Y
        {
            get
            {
                return MyThreshold.Values[_index];
                
            }

           private set
            {
                ;
            }
        }


        public virtual void OnPropertyChanged(string propertyName = null)
        {
            var handler = PropertyChanged;
            if (PropertyChanged != null) PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
