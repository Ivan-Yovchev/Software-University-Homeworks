using System;
using System.Threading;
using VehiclePark.Contracts;
using VehiclePark.Vehicles;

namespace VehiclePark
{
    class VehicleParkMain
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            Car car = new Car("CA2564HH", "Ivan", 2);
            Motorbike motorbike = new Motorbike("H2299AH", "Pesho", 4);
            Truck truck = new Truck("A2442KK", "Gosho", 1);

            IVehiclePark park = new VehiclePark(2, 2);
            Console.WriteLine(park.InsertCar(car, 1, 1, DateTime.Now));
            Console.WriteLine(park.InsertMotorbike(motorbike, 1, 1, DateTime.Now));
        }
    }
}
