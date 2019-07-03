using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Test1
{
    public class DataPair
    {
        public ICollection<Echo> Echos;
        public DataPair()
        {
            Echos = new List<Echo>();
        }
        public ICollection<Point> Get_Points_Of_DataPair ()
        {
            List<Point> PointsList = new List<Point>();
            foreach (var echo in Echos)
            {
                PointsList.Add(echo.Get_Point());
            }
            return PointsList;
        }
    }
}
