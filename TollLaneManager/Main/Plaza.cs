using AutomatedRoadTollingSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace AutomatedRoadTollingSystem
{
	public class Plaza
	{
		String name;
		//Address address; This is in the design document, but I'm not sure what it's for.
		int numLanes;
        decimal fee { get; } //How much toll this plaza charges.
		List<Lane> lanes;
		List<Camera> cameras;
		List<RFIDReader> readers;
		MaintenanceModule maintanence;
		
		public Plaza()
		{
			this.lanes = new List<Lane>();
			this.cameras = new List<Camera>();
			this.readers = new List<RFIDReader>();
			this.maintanence = new MaintenanceModule(this);
		}
		public List<Camera> getCameras()
		{
			return this.cameras;
		}
        public void enableCameras()
        {
            foreach (Camera c in this.cameras){
                c.enable();
             }
        }
        public void addCamera(Camera c)
        {
            this.cameras.Add(c);
        }
        public void addReader(RFIDReader r)
        {
            this.readers.Add(r);
        }    
        public void enableReaders()
        {
            foreach (RFIDReader r in this.readers)
            {
                r.enable();
            }
        }
        public List<RFIDReader> getReaders()
		{
			return this.readers;
		}
		public void addLane(int id, String name)
		{
			Camera cameraToAdd = this.cameras[id];
			RFIDReader rfidToAdd = this.readers[id];
			this.lanes.Add(new Lane(cameraToAdd, rfidToAdd, id, name));
		}
		public void removeLane(Lane lane)
		{
			this.lanes.Remove(lane);
		}
        
        public void serialize()
        {

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(typeof(Plaza));        //Whats this? Gives build error. Is this the correct usage?
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, this);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save("plaza.xml");
                    stream.Close();
                }
            }
            catch (Exception ex)
            {
                //Log exception here
            }

        }
        public static Plaza load()
        {
            Object objectOut = null;
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load("plaza.xml");
                string xmlString = xmlDocument.OuterXml;
                
                using (StringReader read = new StringReader(xmlString))
                {
                    Type outType = typeof(Plaza);

                    XmlSerializer serializer = new XmlSerializer(outType);
                    using (XmlReader reader = new XmlTextReader(read))
                    {
                        objectOut = serializer.Deserialize(reader);
                        reader.Close();
                    }

                    read.Close();
                }
            }
            catch (Exception ex)
            {
                ;
            }

            return (Plaza)objectOut;        
        }
        
    }
}