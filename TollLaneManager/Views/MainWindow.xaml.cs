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
using TollLaneManager.Entities;

namespace TollLaneManager.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
        #endregion


        public void NewLaneClick(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            int random = rand.Next(0, 1000);
            TollLanes.Add(new Lane("Lane #" + random, random));
            TollLanes.Last().status = rand.Next(0, 3);
        }

        private void DeleteLaneClick(object sender, RoutedEventArgs e)
        {
            if (TollLanes.Count != 0)
                TollLanes.RemoveAt(TollLanes.Count - 1);
        }

        /// <summary>
        /// We received a click event on a Lane in our ListBox of lanes. Here is where we'd then adjust the view on the right pane.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LanesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
         
    }
}
