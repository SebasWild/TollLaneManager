using AutomatedRoadTollingSystem;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml;

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
        public bool isOpen;        
     
        public Lane()
		{
			this.laneNumber = laneNumber;
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
        public void enableCameras()
        {
            foreach (Camera c in this.cameras)
            {
                c.enable();
            }
        }
        public void addCamera(Camera c)
        {
            this.cameras.Add(c);
        }
        public void addReader(RFIDReader r)
        {
            this.readers.Add(r);
        }
        public void enableReaders()
        {
            foreach (RFIDReader r in this.readers)
            {
                r.enable();
            }
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