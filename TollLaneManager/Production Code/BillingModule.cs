using AutomatedRoadTollingSystem;
using System;
namespace AutomatedRoadTollingSystem
{
	//This module is used to bill each car that passes through the tolling system either directly though the drivers smart card (SRS Functional Requirements 4.2) 
	//or indirectly through the driver's license plate number (SRS Functional Requirements 4.3).
	public class BillingModule
	{
		//Takes the driver’s smart card number and charges the value of the toll.
		//Parameter: smart card number
		//Returns: ???
		public String chargeSmartCard(String smartCardNumber)
		{
			return "";
			//Stub
		}
		//Sends the plate off to a billing site to charge the plate holder the toll.
		//Parameter: license plate number
		//returns: ???
		public String chargePlateHolder(String plateNumber)
		{
			return "";
			//Stub
		}
	}
}