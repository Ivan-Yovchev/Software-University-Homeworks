using System;
using System.Text;
using VehiclePark.Contracts;
using VehiclePark.Vehicles;

namespace VehiclePark
{
    public class VehiclePark : IVehiclePark
    {
        private ParkLayout layout;
        private ParkData data;

        public VehiclePark(int numberOfsectors, int placesPerSector)
        {
            this.layout = new ParkLayout(numberOfsectors, placesPerSector);
            this.data = new ParkData(numberOfsectors);
        }

        public string InsertCar(Car car, int sector, int placeNumber, DateTime startTime)
        {
            var result = InsertVehicle(car, sector, placeNumber, startTime);
            return result;
        }

        public string InsertMotorbike(Motorbike motorbike, int sector, int placeNumber, DateTime startTime)
        {
            var result = InsertVehicle(motorbike, sector, placeNumber, startTime);
            return result;
        }

        public string InsertTruck(Truck truck, int sector, int placeNumber, DateTime startTime)
        {
            var result = InsertVehicle(truck, sector, placeNumber, startTime);
            return result;
        }

        public string ExitVehicle(string licensePlate, DateTime endTime, decimal amountPaid)
        {
            throw new NotImplementedException();
        }

        public string GetStatus()
        {
            throw new NotImplementedException();
        }

        public string FindVehicle(string licensePlate)
        {
            throw new NotImplementedException();
        }

        public string FindVehiclesByOwner(string owner)
        {
            throw new NotImplementedException();
        }

        private string InsertVehicle(IVehicle vehicle, int sector, int placeNumber, DateTime startTime)
        {
            if (sector > layout.Sectors)
            {
                return string.Format(Constants.NoSectorInPark, sector);
            }

            if (placeNumber > layout.PlacesPerSector)
            {
                return string.Format(Constants.NoPlaceInSector, placeNumber, sector);
            }

            if (data.CarsByPlace.ContainsKey(vehicle))
            {
                return string.Format(Constants.PlaceOcuupied, sector, placeNumber);
            }

            if (data.CarsByLicensePlate.ContainsKey(vehicle.LicensePlate))
            {
                return string.Format(Constants.SameLicensePlate, vehicle.LicensePlate);
            }

            data.CarsByPlace[vehicle] = string.Format(Constants.ParkPlace, sector, placeNumber);
            data.CarsByLicensePlate[vehicle.LicensePlate] = vehicle;
            data.CarsByDate[vehicle] = startTime;
            data.CarsByOwner[vehicle.Owner].Add(vehicle);
            data.NumberOfSectors[sector - 1]--;
            return string.Format(Constants.SuccessfullyParked, vehicle.Type, sector, placeNumber);
        }
    }
}
