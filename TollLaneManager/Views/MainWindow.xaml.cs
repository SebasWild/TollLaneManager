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
            Simulator.init();       //create some lanes.
            this.TollLanes = Simulator.lanes;
            MainGrid.Visibility = System.Windows.Visibility.Collapsed;
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

        public static DependencyProperty GlobalStatusProperty = DependencyProperty.Register("globalStatus", typeof(int), typeof(MainWindow), null);
        public int GlobalStatus
        {
            get
            {
                return (int)GetValue(GlobalStatusProperty);
            }
            set { SetValue(GlobalStatusProperty, value); }
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

        #endregion

        /// <summary>
        /// We received a click event on a Lane in our ListBox of lanes. Here is where we'd then adjust the view on the right pane.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LanesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainGrid.Visibility = System.Windows.Visibility.Visible;
        }

        /// <summary>
        /// Randomly pick a lane to send car through.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TriggerVehicle_Click(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            int laneToPick = rand.Next(TollLanes.Count);

            while(TollLanes[laneToPick].status == 1 || TollLanes[laneToPick].status == 2)
            {
                laneToPick = rand.Next(TollLanes.Count);
            }
            int i = rand.Next(2);
            if (i == 1)
                TollLanes[laneToPick].simulateCarPassingPlate();
            else
                TollLanes[laneToPick].simulateCarPassingRFID();
        }
        /// <summary>
        /// Open the selected lane.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenLaneContextClick(object sender, RoutedEventArgs e)
        {
            SelectedTollLane.open();
            evaluateGlobalStatus();
        }
        /// <summary>
        /// Close the selected lane.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseLaneContextClick(object sender, RoutedEventArgs e)
        {
            SelectedTollLane.close();
            evaluateGlobalStatus();
        }
        /// <summary>
        /// Shuts down the app immediately
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        /// <summary>
        /// Shows the about dialog box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            string message = "AutomatedRoadTollingSystem \n\nAuthors:\nErica Johnson, Huy Ly, Tyler Nolan, Sean O'Connell, Frank Staas and Sebastian Wild";
            string caption = "About";
            MessageBoxButton buttons = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Information;
            MessageBox.Show(message, caption, buttons, icon);
        }
        /// <summary>
        /// Put the selected lane into maintenance mode.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaintainLaneClick(object sender, RoutedEventArgs e)
        {
            SelectedTollLane.maintain();
            evaluateGlobalStatus();
        }
        private void evaluateGlobalStatus()
        {
            int countClosedOrMaint = 0;
            foreach(Lane l in TollLanes)
            {
                if (l.status == 1 || l.status == 2)
                    countClosedOrMaint++;
            }
            double ratio = (double)countClosedOrMaint / (double)TollLanes.Count;
            if (ratio >= 0.75)
                GlobalStatus = 2;
            else if (ratio >= 0.50)
                GlobalStatus = 1;
            else
                GlobalStatus = 0;
        }
    }
}
