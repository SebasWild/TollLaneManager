using AutomatedRoadTollingSystem;
using System;
using System.IO;
using System.Windows.Media.Imaging;
using openalprnet;
namespace AutomatedRoadTollingSystem
{
	//This module will allow us to read the license plate numbers from the pictures and parse the information to a string.
	public class LicensePlateReader
	{
		//Searches for a license plate in the Image an parses the plate info to a string.
		//Returns a string representation of the license plate found.
		public String readLicense(BitmapImage plate)
			{
            return "";
				//Stub
			}
        /*
         * Should work, havent tested it yet.
         * This is how it will go...
         * */
        public void TestALPR()
        {
            var alpr = new AlprNet("us", "/path/to/openalpr.conf", "/path/to/runtime_data");
            if (!alpr.IsLoaded())
            {
                Console.WriteLine("OpenAlpr failed to load!");
                return;
            }
            // Optionally apply pattern matching for a particular region
            alpr.DefaultRegion = "md";

            var results = alpr.Recognize("/path/to/image.jpg");

            for (int i = 0; i < results.Plates.Count; i++)
            {
                AlprPlateResultNet result = results.Plates[i];
                Console.WriteLine("Plate {0}: {1} result(s)", i, result.TopNPlates.Count);
                Console.WriteLine("  Processing Time: {0} msec(s)", result.ProcessingTimeMs);
                foreach (var plate in result.TopNPlates)
                {
                    Console.WriteLine("  - {0}\t Confidence: {1}\tMatches Template: {2}", plate.Characters,
                                      plate.OverallConfidence, plate.MatchesTemplate);
                }
            }

        }

    }
}