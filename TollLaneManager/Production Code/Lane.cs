using AutomatedRoadTollingSystem;
using System;
namespace AutomatedRoadTollingSystem
{
	
	//This class was not mentioned in the design document for whatever reason.
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