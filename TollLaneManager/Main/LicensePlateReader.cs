using AutomatedRoadTollingSystem;
using System;
using System.IO;
using System.Drawing;
using openalprnet;
namespace AutomatedRoadTollingSystem
{
	/// <summary>
    ///     This module will allow us to read the license plate numbers from the pictures and parse the information to a string.
    /// </summary>
    public class LicensePlateReader
	{
		
		/// <summary>
        ///     OpenALPR already reads and parses the liscens plate into a string
        ///     This method should call OpenALPR functionality to read in plates
        /// </summary>
        /// <param name="plateString"></param>
        /// <returns></returns>
        public String readLicense(String imagePath)
		{
            return "";
			//Stub
		}
        
        /// <summary>
        ///     Same as above just readins in the image file instead
        /// </summary>
        /// <param name="plate"></param>
        /// <returns></returns>
        public String readLicense(Image plate)
        {
            return "";
            //Stub
        }
    
        /// <summary>
        ///     This has no functionality as of yet, still needs to be tested
        /// </summary>
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