//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;
//using LiveCharts;
//using LiveCharts.Wpf;
//using LiveCharts.Defaults;

//namespace Test1
//{
//    /// <summary>
//    /// Interaction logic for MainWindow.xaml
//    /// </summary>
//    public partial class MainWindow : Window
//    {
//        LineSeries SeriesChart;
//        public MainWindow()
//        {
//            //InitializeComponent();
//            SeriesCollection SeriesCollection = new SeriesCollection
//            {
//                new LineSeries
//                {
//                    Values = new ChartValues<double> { 3, 5, 7, 4, 9 , 99 }
//                }

//            };


//        }

//        public void controller()
//        {
//            #region Echos
//            Echo e1 = new Echo { distance = 100, amplitude = 10 };
//            Echo e2 = new Echo { distance = 200, amplitude = 15 };
//            Echo e3 = new Echo { distance = 250, amplitude = 7 };
//            Echo e4 = new Echo { distance = 350, amplitude = 19 };
//            #endregion

//            #region Datapairs
//            DataPair dp = new DataPair();
//            dp.Echos.Add(e1);
//            dp.Echos.Add(e2);
//            DataPair dp2 = new DataPair();
//            dp2.Echos.Add(e3);
//            dp2.Echos.Add(e4);
//            #endregion

//            #region Signalways
//            Signalway Sw = new Signalway();
//            Sw.pairs.Add(dp);
//            Sw.pairs.Add(dp2);
//            #endregion

//            List<LiveCharts.Defaults.ObservablePoint> DrawingPoints = Bind_Data(Sw);



//        }


//        public List<ObservablePoint> Bind_Data(Signalway sw)
//        {
//            List<LiveCharts.Defaults.ObservablePoint> drawPoints = new List<ObservablePoint>();

//            foreach (var dp in sw)
//            {
//                foreach (var e in dp.Echos)
//                {
//                    ObservablePoint temp = new ObservablePoint(e.Get_Point().X, e.Get_Point().Y);
//                    drawPoints.Add(temp);
//                }
//            }
//            return drawPoints;
//        }
//    }
//}

using System;
using System.Windows.Media;
using LiveCharts;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;
using System.Collections.Generic;
using System.Diagnostics;
using System.Timers;
using System.Threading;
using LiveCharts.Configurations;

namespace Test1
{
    public class MainWindow
    {
        System.Timers.Timer t = new System.Timers.Timer();
        ChartValues<Echo> EchoList;
        ChartValues<double> ThresholdList;
        static Echo tempo = new Echo() { Amplitude = 10, Distance = 10 };

        public MainWindow()
        {
            Series = new SeriesCollection();

           
            ChartValues<ObservablePoint> AdjustedThresholds;
            ChartValues<double> SensorThresholds;

            //fill chartvalues objects with binded data
            controller( out EchoList, out AdjustedThresholds, out SensorThresholds);
            
            // map the configuration of Echo to make livechart know how to plot it 
            var mapper = Mappers.Xy<Echo>().X(v => v.Distance).Y(v => v.Amplitude);
            //create new scater series to plot the echos with the mapping information
            ScatterSeries ss = new ScatterSeries(mapper);
            //give the mapped series the list of echos to plot
            ss.Values = EchoList;

            //create new line series to plot the adjusted thresholds 
            LineSeries ls = new LineSeries();
            ls.Values = AdjustedThresholds;

            

            Series.Add(ss);
            Series.Add(ls);


            t.Elapsed += timer_elapsed;
            t.Interval = 3000;
            t.Start();

            // Thread.Sleep(8000);




        }

        public void timer_elapsed(object sender, ElapsedEventArgs e)
        {
            //EchoList[0].Amplitude += 10;
            //EchoList[1].Amplitude += 5;
            //EchoList[3].Amplitude += 20;

            tempo.Distance += 100;
        }

        public void controller(out ChartValues<Echo> Echos, out ChartValues<ObservablePoint> AdjustedThresholds, out ChartValues<double> SensorThresholds)
        {

            #region Declaring variables

            #region Echos
            Echo e1 = new Echo { Distance = 100, Amplitude = 10 };
            Echo e2 = new Echo { Distance = 200, Amplitude = 15 };
            Echo e3 = new Echo { Distance = 250, Amplitude = 7 };
            Echo e4 = new Echo { Distance = 350, Amplitude = 19 };
            #endregion

            #region Datapairs
            DataPair dp = new DataPair();
            dp?.Echos?.Add(e1);
            dp?.Echos?.Add(e2);
            DataPair dp2 = new DataPair();
            dp2?.Echos?.Add(e3);
            dp2?.Echos?.Add(e4);
            #endregion

            #region Signalways
            Signalway Sw = new Signalway();
            Sw?.pairs?.Add(dp);
            Sw?.pairs?.Add(dp2);
            #endregion

            #endregion

            #region Binding Echos

            Echos = new ChartValues<Echo>();
            foreach (var Datapair in Sw)
            {
                foreach (var echo in Datapair.Echos)
                {
                    Echos.Add(echo);
                }
            }
            #endregion



            #region Binding adjusted thresholds
            AdjustedThresholds = new ChartValues<ObservablePoint>();
            AdjustedThresholds.Add(new ObservablePoint(0, 0));
            AdjustedThresholds.Add( new ObservablePoint(tempo.Amplitude+100,tempo.Distance+10) );
            AdjustedThresholds.Add(new ObservablePoint(tempo.Amplitude+150, tempo.Distance+20));
            AdjustedThresholds.Add(new ObservablePoint(tempo.Amplitude+300, tempo.Distance+30));

            #endregion

            #region Binding sensor thresholds
            SensorThresholds = new ChartValues<double>(); 
            #endregion

        }


        public SeriesCollection Series { get; set; }
    }
}