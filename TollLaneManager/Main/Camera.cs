using AutomatedRoadTollingSystem;
using System;
using System.Drawing;
using System.IO;

namespace AutomatedRoadTollingSystem
{
	//Provides the ability to capture pictures of license plates for later use with the parsing libraries.
	public class Camera
	{
		private bool status;

        /// <summary>
        ///     Simulates taking a picture.
        /// </summary>
        /// <returns>The random image genearted</returns>
        public Image takePictureSimulated()
        {
            var rand = new Random();
            var files = Directory.GetFiles(".\\SimulatedPictures", "*.jpg");
            LicensePlateReader reader = new LicensePlateReader();
            return Image.FromFile(files[rand.Next(files.Length)]);

        }

		//Disables the camera, closes the lane the camera is monitoring. 
		public void disable()
		{
			this.status = false;
		}

		public void enable()
		{
			this.status = true;
		}
	}
}