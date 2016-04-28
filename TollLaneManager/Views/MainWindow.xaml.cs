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
            IsMainGridVisible = false;
            InitializeComponent();
            Simulator.init();       //create some lanes.
            this.TollLanes = Simulator.lanes;
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
        public static DependencyProperty IsMainGridVisibleProperty = DependencyProperty.Register("IsGridMainVisible", typeof(bool), typeof(MainWindow), new PropertyMetadata(false));
        public bool IsMainGridVisible
        {
            get
            {
                return (bool)GetValue(IsMainGridVisibleProperty);
            }
            set { SetValue(IsMainGridVisibleProperty, value); }
        }
        #endregion

        /// <summary>
        /// We received a click event on a Lane in our ListBox of lanes. Here is where we'd then adjust the view on the right pane.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LanesListBox_SelectionChanged(object sender, MouseEventArgs e)
        {
            IsMainGridVisible = true;
        }

        /// <summary>
        /// Randomly pick a lane to send car through.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TriggerVehicle_Click(object sender, RoutedEventArgs e)
        {
            var openLanes = new ObservableCollection<Lane>();
            foreach(Lane l in TollLanes)
            {
                if (l.status == 0) openLanes.Add(l);
            }
            if (openLanes.Count != 0)
            {
                Random rand = new Random();
                int laneToPick = rand.Next(openLanes.Count - 1);

                while (openLanes[laneToPick].status == 1 || openLanes[laneToPick].status == 2)
                {
                    laneToPick = rand.Next(TollLanes.Count - 1);
                }
                int i = rand.Next(2);
                if (i == 1)
                    openLanes[laneToPick].simulateCarPassingPlate();
                else
                    openLanes[laneToPick].simulateCarPassingRFID();
            }
            else
            {
                string message = "All Lanes are closed - cars cannot go through.";
                string caption = "Warning";
                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Exclamation;
                MessageBox.Show(message, caption, buttons, icon);
            }
        }
        /// <summary>
        /// Open the selected lane.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenLaneContextClick(object sender, RoutedEventArgs e)
        {
            SelectedTollLane.open();
        }
        /// <summary>
        /// Close the selected lane.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseLaneContextClick(object sender, RoutedEventArgs e)
        {
            SelectedTollLane.close();
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
        }
    }
}
