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
		public void disableCamera(Camera cameraToDisable)
		{
			foreach (Camera c in this.lane.getCameras())
            {
                if (c == cameraToDisable) c.disable();
            }
		}
		//Enables the camera sent to this method
		public void enableCamera(Camera cameraToEnable)
        {
            foreach (Camera c in this.lane.getCameras())
            {
                if (c == cameraToEnable) c.enable();
            }
        }
        //Closes a specified lane.
        public void closeLane(Lane laneToClose)
		{
			laneToClose.close();
		}
		//Opens a specified lane.
		public void openLane(Lane laneToOpen)
		{
			laneToOpen.open();
		}
	}
}