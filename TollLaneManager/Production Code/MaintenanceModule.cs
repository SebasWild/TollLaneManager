using AutomatedRoadTollingSystem;
using System;
namespace AutomatedRoadTollingSystem
{
	//This module is used to ensure that all other systems are working correctly and will work to fix them and my turn them off for maintenance.
	public class MaintenanceModule
	{
		Plaza plaza;
		//Disables the camera sent to this method
		public MaintenanceModule(Plaza plaza)
		{
			this.plaza = plaza;
		}
		public void disableCamera(Camera cameraToDisable)
		{
			//Stub
		}
		//Enables the camera sent to this method
		public void enableCamera(Camera cameraToEnable)
		{
			//Stub
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
		//Adds a new lane if space permits.
		public void addNewLane(int id, String name)
		{
			plaza.addLane(id, name);
		}
		//Removes a current lane if space permits.
		public void removeLane(Lane lane)
		{
			plaza.removeLane(lane);
		}
	}
}