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


namespace AutomatedRoadTollingSystem.Entities
{
    /// <summary>
    /// This object represents a traffic lane
    /// 
    /// PROTOTYPE CODE
    /// </summary>
   // [System.Obsolete("New class in Production Code dir. <- Consider moving this here to 'Entities'")]
    public class Lane
    {
        public string name { get; set; }
        public int id { get; set; }
        public int status { get; set; }

        //In a production environment this should be some kind of "Event" object. Of course with a nice toString()
        public ObservableCollection<String> logEntries { get; set; }       //Will hold all log entries. For prototyping purposes this is just a string.

        //Example log strings:
        string[] exEntries = { "A vehicle passed through the lane; RFID HIT; Customer billed", 
                             "A vehilce passed through the lane; RFID MISS; License plate HIT; Customer billed",
                             "ERROR; A car passed through the lane; RFID MISS; License plate MISS; Failed to bill customer!",
                             "A vehicle passed through the lane; RFID HIT; Customer billed; Customer balance low."};            

        public Lane(string name, int id)
        {
            this.name = name;
            this.id = id;

            logEntries = new ObservableCollection<string>();
            populateLog();                                          //Put randon stuff in the log-for prototyping

        }

        private void populateLog()
        {
            Random rand = new Random();
            int noEntries = rand.Next(0, 50);                       //How many random entries to add
            for(int i = noEntries; i > 0; i--)
            {
                logEntries.Add(exEntries[rand.Next(0, 3)]);
            }
        }
    }
}
