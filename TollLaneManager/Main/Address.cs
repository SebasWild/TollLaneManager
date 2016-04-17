namespace AutomatedRoadTollingSystem
{
    internal class Address
    {
        public string street;
        public string zip;
        public string city;
        public string state;
        public Address(string street, string zip, string city, string state)
        {
            this.street = street;
            this.zip = zip;
            this.state = state;
            this.city = city;
        }
    }
}