namespace Estates.Data
{
    using System;
    using System.Text;
    using Estates.Interfaces;

    public abstract class BuildingEstate : Estate, IBuildingEstate
    {
        private int rooms;

        public int Rooms
        {
            get
            {
                return this.rooms;
            }
            set
            {
                if (value < 0 || value > 20)
                {
                    throw new ArgumentException("The rooms must be in the range [0...20]");
                }
                else
                {
                    this.rooms = value;
                }
            }
        }

        public bool HasElevator { get; set; }

        public override string ToString()
        {
            StringBuilder buildingEstate = new StringBuilder();
            buildingEstate
                .Append(base.ToString())
                .AppendFormat(", Rooms: {0}, Elevator: {1}", this.Rooms, this.HasElevator ? "Yes" : "No");

            return buildingEstate.ToString();
        }
    }
}
