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
        public Entities.Lane SelectedTollLane
        {
            get
            {
                return (Entities.Lane)GetValue(SelectedLaneProperty);
            }
            set { SetValue(SelectedLaneProperty, value); }
        }

        public static DependencyProperty TollLanesProperty = DependencyProperty.Register("TollLanes", typeof(ObservableCollection<Entities.Lane>), typeof(MainWindow), new PropertyMetadata(new ObservableCollection<Entities.Lane>()));
        public ObservableCollection<Entities.Lane> TollLanes
        {
            get
            {
                    return (ObservableCollection<Entities.Lane>)GetValue(TollLanesProperty); 
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

        /// <summary>
        /// We received a click event on a Lane in our ListBox of lanes. Here is where we'd then adjust the view on the right pane.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LanesListBox_SelectionChanged(object sender, MouseEventArgs e)
        {

            Entities.Lane laneToAdd = ((Entities.Lane)((ListBox)sender).SelectedItem);
            if (STollLanes.Contains(laneToAdd))
            {
                // remove it
                STollLanes.Remove(laneToAdd);
            }

            // add new, or re add previously deleted lane
            STollLanes.Add(laneToAdd);
            
        }

        /// <summary>
        /// Used for simulation purposes. Will trigger a car to pass through the currently selected lane.
        /// This should trigger subsequent billing and all kinds of stuff.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TriggerVehicle_Click(object sender, RoutedEventArgs e)
        {
            decimal fee = 5.20m;

            // CAMERA SIMULATION
            Camera c = new Camera();
            string capturedPlateNo = c.takePictureSimulated();

            //BILLING SIMULATION
            BillingModule bm = new BillingModule();         
            bm.payTollViaPlate(capturedPlateNo, fee);

            int accountID = DBActions.getAccountIDByPlateNo(capturedPlateNo);
            if (accountID > -1)
            {
                MessageBox.Show("PLATE NO: " + capturedPlateNo + "\tBILLED: $" + fee + " Account Balance: " + DBActions.getBalanceFromAccount(accountID));

            }
            else
            {
                MessageBox.Show("PLATE NO: " + capturedPlateNo + "\tBILLED: $" + fee);
            }
        }

        private void OpenLaneContextClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void CloseLaneContextClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
