using System;
using System.Collections.Generic;
using System.Linq;
namespace VehiclePark.Vehicles
{
    public class Motorbike : Vehicle
    {
        private const decimal MotorbikeRegularRate = 4.75m;
        private const decimal MotorbikeOvertimeRate = 6.2m;

        public Motorbike(string licensePlate, string owner, int reservedHours)
            : base(licensePlate, owner, reservedHours)
        {
        }

        public override decimal RegularRate
        {
            get { return Motorbike.MotorbikeRegularRate; }
        }

        public override decimal OvertimeRate
        {
            get { return Motorbike.MotorbikeOvertimeRate; }
        }

        public override VehicleType Type
        {
            get { return VehicleType.Motorbike; }
        }
    }
}
