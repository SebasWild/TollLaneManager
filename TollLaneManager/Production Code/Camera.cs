using AutomatedRoadTollingSystem;
using System;
using Windows.Media.Capture;
using Windows.Storage;

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
            //https://msdn.microsoft.com/en-us/windows/uwp/audio-video-camera/capture-photos-and-video-with-cameracaptureui
            CameraCaptureUI captureUI = new CameraCaptureUI();
            captureUI.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;
            captureUI.PhotoSettings.CroppedSizeInPixels = new Size(200, 200);
     
            StorageFile photo = await captureUI.CaptureFileAsync(CameraCaptureUIMode.Photo);

            IRandomAccessStream stream = await photo.OpenAsync(FileAccessMode.Read);
            BitmapDecoder decoder = await BitmapDecoder.CreateAsync(stream);
            SoftwareBitmap plateImage = await decoder.GetSoftwareBitmapAsync();

            LicensePlateReader reader = new LicensePlateReader();
            reader.readLicense(plateImage);
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