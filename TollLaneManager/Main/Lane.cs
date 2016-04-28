using AutomatedRoadTollingSystem;
using AutomatedRoadTollingSystem.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Xml;

namespace AutomatedRoadTollingSystem
{

    /// <summary>
    /// A lane object stores information about a lane: the camera module, RFID readers, and some fields like isOpen and name.
    /// </summary>
	public class Lane : DependencyObject //A little of a hack extending this...
    {
        private decimal fee = 5.20m;
        private Camera cam = new Camera();

        List<RFIDReader> readers;
        MaintenanceModule maintenance;
        private int laneNumber { get; set; }
        public String name { get; set; }
        public int numberOfCameras { get; set;}

        //public int status { get; set; }
        public static DependencyProperty Capture = DependencyProperty.Register("capture", typeof(Image), typeof(Object), null);
        public Image capture
        {
            get
            {
                return (Image)GetValue(Capture);
            }
            set { SetValue(Capture, value); }
        }

        public static DependencyProperty StatusProperty = DependencyProperty.Register("status", typeof(int), typeof(Object), null);
        public int status
        {
            get
            {
                return (int)GetValue(StatusProperty);
            }
            set { SetValue(StatusProperty, value); }
        }
        private ObservableCollection<String> _logEntries = null;
        public ObservableCollection<String> logEntries
        {
            get
            {
                if (_logEntries == null) logEntries = new ObservableCollection<string>();
                return _logEntries;
            }
            set
            {
                _logEntries = value;
            }
        }

        public Lane(int laneNumber, string name, int numCameras) {

            numberOfCameras = numCameras;
            //cameras = new List<Camera>();

            //for (int i = 0; i < numCameras; i++)
            //{
            //    cameras.Add(new Camera());
            //}

            this.laneNumber = laneNumber;
			this.name = name;
            this.readers = new List<RFIDReader>();
            this.maintenance = new MaintenanceModule(this);
		}

        internal void open()
        {
            status = 0;
        }

        internal void close()
        {
            status = 2;
        }

        internal void maintain()
        {
            status = 1;
        }

        public Camera getCamera()
        {
            return this.cam;
        }
        public void enableCamera()
        {
            cam.enable();
            status = 0;
        }
        public void disableCamera()
        {
            cam.disable();
            status = 1;
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

        public void simulateCarPassingPlate()
        {
            string capturedPlateNo = cam.takePictureSimulated();

            //BILLING SIMULATION
            logEntries.Add(BillingModule.payTollViaPlate(capturedPlateNo, fee));        //simulate a car passing and log it.
            capture = cam.currentImage;

            //GRAB ACCOUNT FROM DATABASE BASED ON CAR PLATE
            int accountID = DBActions.getAccountIDByPlateNo(capturedPlateNo);
        }

        public void simulateCarPassingRFID()
        {
            //GRAB RANDOM ACCOUNT BASE ON THE COUNT OF ALL THE ACCOUNTS
            Random rnd = new Random();
            int accountID = rnd.Next(0, DBActions.getAllAccountCount());

            //BILLING SIMULATION
            logEntries.Add(BillingModule.payTollViaAccountID(fee, accountID));
        }
    }
}