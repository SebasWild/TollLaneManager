using AutomatedRoadTollingSystem;
using AutomatedRoadTollingSystem.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        
        List<Camera> cameras;
        List<RFIDReader> readers;
        MaintenanceModule maintenance;
        private int laneNumber { get; set; }
        public String name { get; set; }
        //public int status { get; set; }

        public static DependencyProperty StatusProperty = DependencyProperty.Register("status", typeof(int), typeof(Object), null);
        public int status
        {
            get
            {
                return (int)GetValue(StatusProperty);
            }
            set { SetValue(StatusProperty, value); }
        }
        public ObservableCollection<String> logEntries { get; set; }       //Will hold all log entries. For prototyping purposes this is just a string.
  
        public Lane(int laneNumber, string name) { 
			this.laneNumber = laneNumber;
			this.name = name;
            this.cameras = new List<Camera>();
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

        public void simulateCarPassingPlate()
        {
            // CAMERA SIMULATION
            Camera c = new Camera();
            string capturedPlateNo = c.takePictureSimulated();

            //BILLING SIMULATION
            BillingModule bm = new BillingModule();
            bm.payTollViaPlate(capturedPlateNo, fee);

            //GRAB ACCOUNT FROM DATABASE BASED ON CAR PLATE
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

        public void simulateCarPassingRFID()
        {
            // CAMERA SIMULATION
            Camera c = new Camera();
            string capturedPlateNo = c.takePictureSimulated();

            //BILLING SIMULATION
            BillingModule bm = new BillingModule();
            bm.payTollViaPlate(capturedPlateNo, fee);

            //GRAB RANDOM ACCOUNT BASE ON THE COUNT OF ALL THE ACCOUNTS
            Random rnd = new Random();
            int accountID = rnd.Next(0, DBActions.getAllAccountCount() - 1);

            if (accountID > -1)
            {
                MessageBox.Show("PLATE NO: " + capturedPlateNo + "\tBILLED: $" + fee + " Account Balance: " + DBActions.getBalanceFromAccount(accountID));

            }
            else
            {
                MessageBox.Show("PLATE NO: " + capturedPlateNo + "\tBILLED: $" + fee);
            }
        }
    }
}