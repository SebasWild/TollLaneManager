using AutomatedRoadTollingSystem;
using System;
using System.Collections.Generic;
namespace AutomatedRoadTollingSystem
{
	//This module will allow us to read the license plate numbers from the pictures and parse the information to a string.
	public class RFIDReader
	{
		private bool status;
		//Takes the RFID data being transmitted by a passing car, and gets the corresponding smart card details connected to the account.
		public String processRFID(Object rfid_Data)
		{
			return "";
			//Stub
		}
		public void enable()
		{
			//Stub
			this.status = true;
		}
		public void disable()
		{
			//Stub
			this.status = false;
		}
		
	}
}