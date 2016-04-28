using AutomatedRoadTollingSystem;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AutomatedRoadTollingSystem
{

    /// <summary>
    /// A lane object stores information about a lane: the camera module, RFID readers, and some fields like isOpen and name.
    /// </summary>
	public class Lane
	{
        List<Lane> lanes;
        List<Camera> cameras;
        List<RFIDReader> readers;
        MaintenanceModule maintenance;
        private int laneNumber { get; set; }
        private String name { get; set; }
        public int status { get; set; }
        private bool isOpen;        //Why is this private?
        public ObservableCollection<String> logEntries { get; set; }       //Will hold all log entries. For prototyping purposes this is just a string.
        /* Events should be posted here so that they may be displayed in the UI.
        //Example log strings:
        string[] exEntries = { "A vehicle passed through the lane; RFID HIT; Customer billed",
                             "A vehilce passed through the lane; RFID MISS; License plate HIT; Customer billed",
                             "ERROR; A car passed through the lane; RFID MISS; License plate MISS; Failed to bill customer!",
                             "A vehicle passed through the lane; RFID HIT; Customer billed; Customer balance low."};
        */
        public Lane(Camera camera, RFIDReader reader, int Id, String name)
		{
			this.laneNumber = Id;
			this.name = name;
			this.lanes = new List<Lane>();
            this.cameras = new List<Camera>();
            this.readers = new List<RFIDReader>();
            this.maintenance = new MaintenanceModule(this);
		}
        public List<Camera> getCameras()
        {
            return this.cameras;
        }
		public void close()
		{
			this.isOpen = false;
		}
		public void open()
		{
			this.isOpen = true;
		}
	}
}