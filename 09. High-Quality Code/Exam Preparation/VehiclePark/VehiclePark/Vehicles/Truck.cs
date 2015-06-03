using System;
using System.Collections.Generic;
using System.Linq;
namespace VehiclePark.Vehicles
{
    public class Truck : Vehicle
    {
        private const decimal TruckRegularRate = 4.75m;
        private const decimal TruckOvertimeRate = 6.2m;

        public Truck(string licensePlate, string owner, int reservedHours)
            : base(licensePlate, owner, reservedHours)
        {
        }

        public override decimal RegularRate
        {
            get { return Truck.TruckRegularRate; }
        }

        public override decimal OvertimeRate
        {
            get { return Truck.TruckOvertimeRate; }
        }

        public override VehicleType Type
        {
            get { return VehicleType.Truck; }
        }
    }
}
