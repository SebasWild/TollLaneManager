using AutomatedRoadTollingSystem;
using System;
namespace AutomatedRoadTollingSystem
{

    /// <summary>
    /// A lane object stores information about a lane: the camera module, RFID readers, and some fields like isOpen and name.
    /// </summary>
	public class Lane
	{
        private Camera primaryCamera;
        private RFIDReader primaryReader;
        private RFIDReader secondaryReader;
        private Camera secondaryCamera;
        private int laneNumber;
        private String name;
        private bool isOpen;
        public Lane(Camera camera, RFIDReader reader, int Id, String name)
		{
			this.laneNumber = Id;
			this.name = name;
			this.primaryCamera = camera;
			this.primaryReader = reader;
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