using AutomatedRoadTollingSystem;
using System;
using System.Collections.Generic;

namespace AutomatedRoadTollingSystem
{
	public class Plaza
	{
		String name;
		//Address address; This is in the design document, but I'm not sure what it's for.
		int numLanes;
		List<Lane> lanes;
		List<Camera> cameras;
		List<RFIDReader> readers;
		MaintenanceModule maintanence;
		
		public Plaza()
		{
			this.lanes = new List<Lane>();
			this.cameras = new List<Camera>();
			this.readers = new List<RFIDReader>();
			this.maintanence = new MaintenanceModule(this);
		}
		public List<Camera> getCameras()
		{
			return this.cameras;
		}
		public List<RFIDReader> getReaders()
		{
			return this.readers;
		}
		public void addLane(int id, String name)
		{
			Camera cameraToAdd = this.cameras[id];
			RFIDReader rfidToAdd = this.readers[id];
			this.lanes.Add(new Lane(cameraToAdd, rfidToAdd, id, name));
		}
		public void removeLane(Lane lane)
		{
			this.lanes.Remove(lane);
		}
	}
}