namespace FarmersCreed.Units
{
    using System;

    public abstract class Plant : FarmUnit
    {
        private const int WaterDeafultGrowValue = 2;
        private const int WitherDeafultDecreaseValue = 1;
        private const int GrowDefaultValue = 1;

        private int growTime;

        public Plant(string id, int health, int productionQuantity, int growTime)
            : base(id, health, productionQuantity)
        {
            this.GrowTime = growTime;
        }

        public bool HasGrown
        {
            get
            {
                return this.growTime <= 0;
            }
        }

        public int GrowTime
        {
            get
            {
                return this.growTime;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Grow time cannot be negative");
                }
                else
                {
                    this.growTime = value;
                }
            }
        }

        public virtual void Water()
        {
            this.Health += WaterDeafultGrowValue;
        }

        public virtual void Wither()
        {
            this.Health -= WitherDeafultDecreaseValue;
        }

        public virtual void Grow()
        {
            this.GrowTime -= GrowDefaultValue;
        }

        public override string ToString()
        {
            if (this.IsAlive == true)
            {
                return string.Format("{0}, Grown: {1}", base.ToString(), this.HasGrown ? "Yes" : "No");
            }
            else
            {
                return base.ToString();
            }
        }
    }
}
