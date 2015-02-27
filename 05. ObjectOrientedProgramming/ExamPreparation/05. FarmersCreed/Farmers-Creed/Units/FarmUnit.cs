using FarmersCreed.Interfaces;

namespace FarmersCreed.Units
{
    using System;

    public abstract class FarmUnit : GameObject, IProductProduceable 
    {
        protected int health;
        protected int productionQuantity;

        public FarmUnit(string id, int health, int productionQuantity)
            : base(id)
        {
            this.Health = health;
            this.ProductionQuantity = productionQuantity;
        }

        public int Health { get; set; }

        public bool IsAlive
        {
            get
            {
                return this.Health > 0;
            }
        }

        public int ProductionQuantity
        {
            get
            {
                return this.productionQuantity;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Production quantity cannot be negative");
                }
                else
                {
                    this.productionQuantity = value;
                }
            }
        }

        public abstract Product GetProduct();

        public override string ToString()
        {
            return string.Format("{0}, {1}", base.ToString(), this.IsAlive ? "Health: " + this.Health : "DEAD");
        }
    }
}
