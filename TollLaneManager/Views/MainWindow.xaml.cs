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
            //TODO: call all this junk somewhere else...
            AutomatedRoadTollingSystem.LicensePlateReader rdr = new AutomatedRoadTollingSystem.LicensePlateReader();
           //rdr.TestALPR();
            DBActions.initDB();       //Initialize the database, fill in some data.

            //Quick test of basic billing functionality:
            //Simulator.testBillingModule();
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
            
        }

        /// <summary>
        /// Used for simulation purposes. Will trigger a car to pass through the currently selected lane.
        /// This should trigger subsequent billing and all kinds of stuff.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TriggerVehicle_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void OpenLaneContextClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void CloseLaneContextClick(object sender, RoutedEventArgs e)
        {

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
            string message = "AutomatedRoadTollingSystem \n\nAuthors:\nHuy Ly, Tyler Nolan, Sean O'Connel, Frank Staas and Sebastian Wild";
            string caption = "About";
            MessageBoxButton buttons = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Information;
            MessageBox.Show(message, caption, buttons, icon);
        }
    }
}
