using System;
using System.Collections.Generic;
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


namespace TollLaneManager
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

        public void LaneClick(object sender, RoutedEventArgs e)
        {
            ((Button)sender).Content = "Clicked!";
        }

        public void NewLaneClick(object sender, RoutedEventArgs e)
        {
           
            // add a new row definitions (needed to add a new row to the grid)
            LaneGrid.RowDefinitions.Add(new RowDefinition()); 
            LaneGrid.Height += 25; // add 25 to the total height of the grid to compensate for the new row

            // make a sub-grid to add to the parent grid (this is what goes in the newly created row)
            Grid g = new Grid(); 
            Grid.SetRow(g, LaneGrid.Children.Count); // add the new sub-grid into the parent grids last row
            g.HorizontalAlignment = HorizontalAlignment.Left; //allign the grid left
            g.Width = 75; // width of the new grid 

            // create and set new column definitions for the size proporitons of the sub-grid
            ColumnDefinition cd1 = new ColumnDefinition();
            cd1.Width = new GridLength(5, GridUnitType.Star); // column space for button
            
            ColumnDefinition cd2 = new ColumnDefinition();
            cd2.Width = new GridLength(1, GridUnitType.Star); // column space for ellipse

            // add the new column defintions to the grid
            g.ColumnDefinitions.Add(cd1);
            g.ColumnDefinitions.Add(cd2);

            // create a new lane button and add it to the sub-grid
            Button b = new Button();
            b.Content = "Lane #" + (LaneGrid.Children.Count + 1); // set the text of the button
            b.Click += new RoutedEventHandler(LaneClick); // add the generic action handler for each button
            b.Height = 20;
            b.Width = 55;
            g.Children.Add(b); // add it to the grid

            Ellipse ellipse = new Ellipse();
            ellipse.Height = 10;
            ellipse.Width = 10;
            ellipse.Fill = new SolidColorBrush(Colors.Green);

            Grid.SetColumn(ellipse, 2); // set the column the ellipse will be in to the second column
            g.Children.Add(ellipse);    // add the ellipse

            LaneGrid.Children.Add(g); // add the new sub-grid row to the parent grid
        }
    }
}
