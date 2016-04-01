using AutomatedRoadTollingSystem;
using System;
namespace AutomatedRoadTollingSystem
{
	//Provides the ability to capture pictures of license plates for later use with the parsing libraries.
	public class Camera
	{
		private bool status;
		//Takes a picture of the current view of the camera, finds a license plate and returns a string representation of that license plate.
		//Returns the string representation of the licence plate.
		public String takePicture()
		{
            //Stub
            return "";
		}
		//Disables the camera, closes the lane the camera is monitoring. 
		public void disable()
		{
			//Stub
			this.status = false;
		}
		public void enable()
		{
			//Stub
			this.status = true;
		}
	}
}