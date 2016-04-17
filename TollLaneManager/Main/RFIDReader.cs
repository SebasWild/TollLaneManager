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
            //I guess we can arbitrarilly define the data structure of the rfid data being sent?
            //Can we just say the RFID data being sent is just the smart card number, since that is all we're getting from it?
            return (String)rfid_Data;
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