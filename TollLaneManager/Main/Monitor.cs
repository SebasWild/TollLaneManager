using AutomatedRoadTollingSystem;
using System;
namespace AutomatedRoadTollingSystem
{
	//Allows the for the ability to identify passing cars incase no onboard system is available. 
	//See Functional Requirements 4.1 and 4.3 in the SRS. 
	//And monitors any car that does contain an RFID device.
	public class Monitor
	{
		private Plaza plaza;
		//Turns all toll lane cameras on to take pictures of passing cars.
		public void start()
		{
            //Stub
            //Deserialize a previous instance of the plaza and load it
            try
            {
                this.plaza = Plaza.load();
            }
            catch
            {
                this.plaza = new Plaza();
            }
            //enable cameras
            this.plaza.enableCameras();
            //enable RFID readers
            this.plaza.enableReaders();

		}

        public void close()
        {
            this.plaza.serialize();
        }
	}
}