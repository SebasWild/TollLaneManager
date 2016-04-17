using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AutomatedRoadTollingSystem.Entities;
using AutomatedRoadTollingSystem.Common;

namespace AutomatedRoadTollingSystem.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeLanes();
            //TODO: call all this junk somewhere else...
            AutomatedRoadTollingSystem.LicensePlateReader rdr = new AutomatedRoadTollingSystem.LicensePlateReader();
            rdr.TestALPR();
            DBgenerator.initDB();       //Initialize the database, fill in some data.

            //Quick test of basic billing functionality:
            Simulator.testBillingModule();
        }
        /// <summary>
        /// Called on starting the applications. Will initialize some lanes.
        /// </summary>
        private void InitializeLanes()
        {
            
        }

        //The View binds to the following properties. 
        #region DependencyProperties
        public static DependencyProperty SelectedLaneProperty = DependencyProperty.Register("SelectedTollLane", typeof(Lane), typeof(MainWindow), null);
        public Lane SelectedTollLane
        {
            get
            {
                return (Lane)GetValue(SelectedLaneProperty);
            }
            set { SetValue(SelectedLaneProperty, value); }
        }

        public static DependencyProperty TollLanesProperty = DependencyProperty.Register("TollLanes", typeof(ObservableCollection<Lane>), typeof(MainWindow), new PropertyMetadata(new ObservableCollection<Lane>()));
        public ObservableCollection<Lane> TollLanes
        {
            get
            {
                    return (ObservableCollection<Lane>)GetValue(TollLanesProperty); 
            }
            set { SetValue(TollLanesProperty, value); }
        }
        //Reports to display in the "Reports" expander.
        public static DependencyProperty ReportsProperty = DependencyProperty.Register("Reports", typeof(ObservableCollection<Report>), typeof(MainWindow), new PropertyMetadata(new ObservableCollection<Report>()));
        public ObservableCollection<Report> Reports
        {
            get
            {
                return (ObservableCollection<Report>)GetValue(ReportsProperty);
            }
            set { SetValue(ReportsProperty, value); }
        }
        public static DependencyProperty STollLanesProperty = DependencyProperty.Register("STollLanes", typeof(ObservableCollection<Tabitem>), typeof(MainWindow), new PropertyMetadata(new ObservableCollection<Tabitem>()));
        public ObservableCollection<Tabitem> STollLanes
        {
            get
            {

                return (ObservableCollection<Tabitem>)GetValue(STollLanesProperty);
            }
            set
            {
                SetValue(STollLanesProperty, value);

            }
        }
        #endregion


        public void NewLaneClick(object sender, RoutedEventArgs e)
        {
            /*
            Random rand = new Random();
            int random = rand.Next(0, 1000);
            TollLanes.Add(new Lane("Lane #" + random, random));
            TollLanes.Last().status = rand.Next(0, 3);
            */
        }

        private void DeleteLaneClick(object sender, RoutedEventArgs e)
        { /*
            if (TollLanes.Count != 0)
                STollLanes.Remove(TollLanes.ElementAt(TollLanes.Count - 1));
            TollLanes.RemoveAt(TollLanes.Count - 1);
            */

        }

        private void DeleteLaneContextClick(object sender, RoutedEventArgs e)
        {
            /*
            Lane laneToRemove = (Lane)((MenuItem)sender).DataContext;
            STollLanes.Remove(laneToRemove);
            TollLanes.Remove(laneToRemove);
            */
        }

        /// <summary>
        /// We received a click event on a Lane in our ListBox of lanes. Here is where we'd then adjust the view on the right pane.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LanesListBox_SelectionChanged(object sender, MouseEventArgs e)
        {
            /*
            Lane laneToAdd = ((Lane)((ListBox)sender).SelectedItem);
            if (STollLanes.Contains(laneToAdd))
            {
                // remove it
                STollLanes.Remove(laneToAdd);
            }

            // add new, or re add previously deleted lane
            STollLanes.Add(laneToAdd);
            */
        }

        private void MakeTab(object sender, RoutedEventArgs e)
        {
            /*
            Lane laneToAdd = (Lane)((MenuItem)sender).DataContext;
            if (STollLanes.Contains(laneToAdd))
            {
                // remove it
                STollLanes.Remove(laneToAdd);
            }

            // add new, or re add previously deleted lane
            STollLanes.Add(laneToAdd);
            */
        }

        private void LanePropertiesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            PropertiesWindow pWindow = new PropertiesWindow();
            pWindow.Show();
        }

        private void ReportPropertiesMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MakeReportTab(object sender, RoutedEventArgs e)
        {
            /*
            Report newReport = new Report("Custom Report", DateTime.Now, DateTime.Now.AddDays(-1), SelectedTollLane.logEntries.ToList());
            Reports.Add(newReport);

            if(STollLanes.Contains(newReport))
            {
                STollLanes.Remove(newReport);
            }
            STollLanes.Add(newReport);
            */
        }
         
    }
}
