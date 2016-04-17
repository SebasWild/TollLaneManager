using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollLaneManager
{
    public class Vehicle
    {
        private Boolean hasSmartCard;
        private String licensePlateNum;
        private String vehicleMake;
        private String model;
        int vehicleYear;
        private String vehicleType;

        public String getPlate()
        {
            return this.licensePlateNum;
        }
        
    }
}
