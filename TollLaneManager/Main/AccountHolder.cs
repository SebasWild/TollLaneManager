using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollLaneManager
{
    public class AccountHolder
    {
        private String firstName;
        private String lastName;
        private Address address;
        private Vehicle vehicle;
        //Stub
        public AccountHolder(String firstName, String lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }
        public void setVehicle(Vehicle vehicle)
        {
            this.vehicle = vehicle;
        }
        public void setAddress(Address address)
        {
            this.address = address;
        }
    }
}
