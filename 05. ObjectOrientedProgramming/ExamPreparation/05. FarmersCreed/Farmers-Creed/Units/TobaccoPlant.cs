namespace FarmersCreed.Units
{
    using System;

    public class TobaccoPlant : Plant
    {
        private const int TobaccoDefaultHealth = 12;
        private const int TobaccoDefaultGrowTime = 4;
        private const ProductType TobaccoType = ProductType.Tobacco;
        private const int TobaccoDefaultQuantity = 10;
        public TobaccoPlant(string id)
            : base(id, TobaccoDefaultHealth, TobaccoDefaultQuantity, TobaccoDefaultGrowTime)
        {
        }

        public override void Grow()
        {
            this.GrowTime -= 2;
        }

        public override Product GetProduct()
        {
            if (!this.HasGrown)
            {
                throw new ArgumentException("The plant has not grown yet");
            }
            else if (!this.IsAlive)
            {
                throw new ArgumentException("The plant is dead");
            }

            return new Product(this.Id + "Product", ProductType.Tobacco, this.ProductionQuantity);
        }
    }
}
