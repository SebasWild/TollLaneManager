using AutomatedRoadTollingSystem;
using System;
namespace AutomatedRoadTollingSystem
{
	//Simulator class for simulating functionality of the system.
	public static class Simulator
	{
	//stub
    /// <summary>
    /// Tests the billing component. 
    /// 
    /// TODO: make this an actual test.
    /// </summary>
    public static void testBillingModule()
        {
            //Test billing a dummy acc. WIP code
            BillingModule bm = new BillingModule();
            bm.payToll(0, "QWERTY", 100.00m);        //runs sync but w/e
        }
	}
    
}