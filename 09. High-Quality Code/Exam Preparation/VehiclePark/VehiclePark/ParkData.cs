using System;
using System.Collections.Generic;
using VehiclePark.Contracts;
using Wintellect.PowerCollections;

namespace VehiclePark
{
    public class ParkData
    {
        public ParkData(int numberOfSectors)
        {
            CarsByPlace = new Dictionary<IVehicle, string>();
            CarsByLicensePlate = new Dictionary<string, IVehicle>();
            CarsByDate = new Dictionary<IVehicle, DateTime>();
            CarsByOwner = new MultiDictionary<string, IVehicle>(false);
            NumberOfSectors = new int[numberOfSectors];
        }

        public Dictionary<IVehicle, string> CarsByPlace { get; set; }
        public Dictionary<string, IVehicle> CarsByLicensePlate { get; set; }
        public Dictionary<IVehicle, DateTime> CarsByDate { get; set; }
        public MultiDictionary<string, IVehicle> CarsByOwner { get; set; }
        public int[] NumberOfSectors { get; set; }
    }
}
