namespace FarmersCreed.Units
{
    using System;
    using FarmersCreed.Interfaces;

    public class Swine : Animal
    {
        public Swine(string id)
            : base(id, 20, 1)
        {
        }

        public override void Starve()
        {
            this.Health -= 3;
        }

        public override Product GetProduct()
        {
            if (!this.IsAlive)
            {
                throw new ArgumentException("Cannot produce from dead swine");
            }

            this.Health = 0;
            return new Food(this.Id + "Product", ProductType.PorkMeat, FoodType.Meat, this.ProductionQuantity, 5);
        }

        public override void Eat(IEdible food, int quantity)
        {
            this.Health += food.HealthEffect * 2 * quantity;
        }
    }
}
