namespace FarmersCreed.Units
{
    using System;

    public abstract class FoodPlant : Plant
    {
        public FoodPlant(string id, int health, int productionQuantity, int growTime, int healthEffect)
            : base(id, health, productionQuantity, growTime)
        {
            this.ProductHealthEffect = healthEffect;
        }

        public int ProductHealthEffect { get; set; }

        public override void Water()
        {
            this.Health += 1;
        }

        public override void Wither()
        {
            this.Health -= 2;
        }
    }
}
