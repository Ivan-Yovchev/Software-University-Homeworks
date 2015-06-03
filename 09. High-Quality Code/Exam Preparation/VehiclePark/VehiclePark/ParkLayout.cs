using System;

namespace VehiclePark
{
    public class ParkLayout
    {
        private int numberOfSectors;
        private int placesPerSector;

        public ParkLayout(int numberOfSectors, int placesPerSector)
        {
            this.Sectors = numberOfSectors;
            this.placesPerSector = placesPerSector;
        }

        public int Sectors
        {
            get { return this.numberOfSectors; }
            private set
            {
                if (value <= 0)
                {
                    throw new Exception("The number of sectors must be positive.");
                }

                this.numberOfSectors = value;
            }
        }

        public int PlacesPerSector
        {
            get { return this.placesPerSector; }
            private set
            {
                if (value <= 0)
                {
                    throw new Exception("The number of places per sector must be positive.");
                }

                this.placesPerSector = value;
            }
        }
    }
}
