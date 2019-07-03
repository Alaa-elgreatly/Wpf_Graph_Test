using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveCharts;
using System.ComponentModel;

namespace Test1
{
    public class Echo : INotifyPropertyChanged
    {
        private double distance;
        private double amplitude;



        public event PropertyChangedEventHandler PropertyChanged;

        public Echo()
        {

        }

        public double Distance
        {
            get
            {
                return distance;
            }

            set
            {
                distance = value;
                OnPropertyChanged("Distance");
            }
        }

        public double Amplitude
        {
            get
            {
                return amplitude;
            }

            set
            {
                amplitude = value;
                OnPropertyChanged("Amplitude");
            }
        }

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            var handler = PropertyChanged;
            if (PropertyChanged != null) PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public System.Windows.Point Get_Point()
        {
            return new System.Windows.Point(Distance, Amplitude);
        }
    }
}
