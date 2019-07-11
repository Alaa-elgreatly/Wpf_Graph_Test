using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    public class subdata /*: INotifyPropertyChanged*/
    {
        protected string name;
        protected List<double> values;
        protected static List<double> distances = new List<double>() { 14 ,42 ,70 ,91 ,112 ,133 ,161 ,189 ,235 ,280 ,351, 456};

        //public event PropertyChangedEventHandler PropertyChanged;

        public subdata(string n)
        {
            name = n;
            Values = new List<double>();
            for (int i = 0; i < 12; i++)
            {
                Values.Add(i);
            }

        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public List<double> Values
        {
            get
            {
                return values;
            }

            set
            {
                values = value;
            }
        }

        public static List<double> Distances
        {
            get
            {
                return distances;
            }

            set
            {
                distances = value;
            }
        }

        //protected virtual void OnPropertyChanged(string propertyName = null)
        //{
        //    var handler = PropertyChanged;
        //    if (PropertyChanged != null) PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}
