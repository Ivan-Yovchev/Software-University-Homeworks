namespace VehiclePark.Vehicles
{
    public class Car : Vehicle
    {
        private const decimal CarRegularRate = 2.0m;
        private const decimal CarOvertimeRate = 3.5m;

        public Car(string licensePlate, string owner, int reservedHours)
            : base(licensePlate, owner, reservedHours)
        { 
        }

        public override decimal RegularRate
        {
            get { return Car.CarRegularRate; }
        }

        public override decimal OvertimeRate
        {
            get { return Car.CarOvertimeRate; }
        }

        public override VehicleType Type
        {
            get { return VehicleType.Car; }
        }
    }
}
