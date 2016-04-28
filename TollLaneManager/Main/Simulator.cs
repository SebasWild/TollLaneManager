using AutomatedRoadTollingSystem;
using System;
using System.Collections.Generic;

namespace AutomatedRoadTollingSystem
{
    //Simulator class for simulating functionality of the system.
  

    public static class Simulator
	{
        public static List<Lane> lanes { get; set; }

        public static void init()
        {
            lanes.Add(new Lane(1, "Lane 1"));
            lanes.Add(new Lane(2, "Lane 2"));
            lanes.Add(new Lane(3, "Lane 3"));
            lanes.Add(new Lane(4, "Lane 4"));
            lanes.Add(new Lane(5, "Lane 5"));
            lanes.Add(new Lane(6, "Lane 6"));
            lanes.Add(new Lane(7, "Lane 7"));
            lanes.Add(new Lane(8, "Lane 8"));
        }
	}
    
}