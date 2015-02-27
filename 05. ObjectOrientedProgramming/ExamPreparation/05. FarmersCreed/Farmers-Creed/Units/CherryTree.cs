namespace FarmersCreed.Units
{
    using System;

    public class CherryTree : FoodPlant
    {
        public CherryTree(string id)
            : base(id, 14, 4, 3, 2)
        {
        }

        public override Product GetProduct()
        {
            if (!this.IsAlive)
            {
                throw new ArgumentException("Cannot reap dead cherry tree");
            }

            return new Food(this.Id + "Product", ProductType.Cherry, FoodType.Organic, this.ProductionQuantity, this.ProductHealthEffect);
        }
    }
}
