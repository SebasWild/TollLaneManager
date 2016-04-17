using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedRoadTollingSystem.Entities
{
    /// <summary>
    /// A Report will hold a log of events over a specified time period.
    /// 
    /// Maybe even more detailed statistics.
    /// </summary>
    public class Report : Tabitem
    {
        public DateTime start { get; set; }
        public DateTime end { get; set; }

        public string name { get; set; }                                   //Name of the report

        public ObservableCollection<String> logEntries { get; set; }       //Will hold all log entries for that time period.

        public Report(String name, DateTime start, DateTime end, List<String> logEntries)
        {
            this.start = start;
            this.end = end;
            this.name = name;
            this.logEntries = new ObservableCollection<string>(logEntries);
        }
    }
}
