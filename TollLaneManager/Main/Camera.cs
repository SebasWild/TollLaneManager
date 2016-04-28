using AutomatedRoadTollingSystem;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AutomatedRoadTollingSystem
{
	//Provides the ability to capture pictures of license plates for later use with the parsing libraries.
	public class Camera
	{
		private bool status;
        public ImageSource currentImage { get; set; }

        /// <summary>
        ///     Simulates taking a picture.
        /// </summary>
        /// <returns>The random image genearted</returns>
        public String takePictureSimulated()
        {
            try
            {
                var rand = new Random();
                var files = Directory.GetFiles(@"..\\..\\..\\SimulatedPictures", "*.jpg");
                //var files = Directory.GetFiles(@".\\SimulatedPictures", "*.jpg");
                LicensePlateReader reader = new LicensePlateReader();
                String file = files[rand.Next(files.Length)];

                currentImage = new BitmapImage(new Uri(String.Format(@"..\\..\\..\\SimulatedPictures\\{0}.jpg", Path.GetFileNameWithoutExtension(file)), UriKind.Relative));
                //currentImage = new BitmapImage(new Uri(String.Format(@".\\SimulatedPictures\\{0}.jpg", Path.GetFileNameWithoutExtension(file)), UriKind.Relative));
                currentImage.Freeze();

                return Path.GetFileNameWithoutExtension(file);
            }
            catch(DirectoryNotFoundException e)
            {
                Console.WriteLine(e);
                return "";
            }
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