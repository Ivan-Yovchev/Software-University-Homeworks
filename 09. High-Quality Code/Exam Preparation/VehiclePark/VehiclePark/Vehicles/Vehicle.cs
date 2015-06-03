using System;
using System.Text.RegularExpressions;

namespace VehiclePark.Vehicles
{
    using Contracts;

    public abstract class Vehicle : IVehicle
    {
        private string licensePlate;

        protected Vehicle(string licensePlate, string owner, int reservedHours)
        {
            this.LicensePlate = licensePlate;
            this.Owner = owner;
            this.ReservedHours = reservedHours;
        }

        public string LicensePlate
        {
            get { return this.licensePlate; }
            private set
            {
                var foundMatch = Regex.IsMatch(value, @"^\w{1,2}\d{4}\w{2}$");
                if (foundMatch != true)
                {
                    throw new Exception("Invalid license plate");
                }
                else
                {
                    this.licensePlate = value;
                }
            }
        }

        public string Owner { get; private set; }

        public abstract decimal RegularRate { get; }

        public abstract decimal OvertimeRate { get; }

        public int ReservedHours { get; private set; }

        public abstract VehicleType Type { get; }

        public override string ToString()
        {
            return string.Format("{0} [{1}], owned by {2}", this.Type, this.LicensePlate, this.Owner);
        }
    }
}
