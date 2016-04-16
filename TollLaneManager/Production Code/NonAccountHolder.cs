using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TollLaneManager {
    
    public class NonAccountHolder {
        
        private String firstName;
        private String lastName;
        private Address address;
        
        public NonAccountHolder(String first, String last, Address address) {
            this.address = address;
            this.firstName = first;
            this.lastName = last;

        }
    }
}
