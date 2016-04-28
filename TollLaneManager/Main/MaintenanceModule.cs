using AutomatedRoadTollingSystem;
using System;
namespace AutomatedRoadTollingSystem
{
	//This module is used to ensure that all other systems are working correctly and will work to fix them and my turn them off for maintenance.
	public class MaintenanceModule
	{
		Lane lane;
		//Disables the camera sent to this method
		public MaintenanceModule(Lane lane)
		{
			this.lane = lane;
		}
		public void disableCamera()
		{
            lane.disableCamera();  
		}
		//Enables the camera sent to this method
		public void enableCamera(Camera cameraToEnable)
        {
            lane.enableCamera();
        }
        //Closes a specified lane.
        public void closeLane(Lane laneToClose)
		{
			laneToClose.close();
		}
        //Closes a lane for maintenance
        public void mainTainLane(Lane laneToClose)
        {
            laneToClose.maintain();
        }
        //Opens a specified lane.
        public void openLane(Lane laneToOpen)
		{
			laneToOpen.open();
		}
	}
}