namespace FarmersCreed.Units
{
    using System;
    using FarmersCreed.Interfaces;

    public class Cow : Animal
    {
        public Cow(string id)
            : base(id, 15, 6)
        {
        }

        public override Product GetProduct()
        {
            if (!this.IsAlive)
            {
                throw new ArgumentException("Cannot milk dead cow");
            }

            this.Health -= 2;
            return new Food(this.Id + "Product", ProductType.Milk, FoodType.Organic, this.ProductionQuantity, 4);
        }

        public override void Eat(IEdible food, int quantity)
        {
            if (food.FoodType == FoodType.Organic)
            {
                this.Health += food.HealthEffect * quantity;
            }
            else if (food.FoodType == FoodType.Meat)
            {
                this.Health -= food.HealthEffect * quantity;
            }
        }
    }
}
