namespace FarmersCreed.Units
{
    using System;
    using FarmersCreed.Interfaces;

    public abstract class Animal : FarmUnit
    {
        public Animal(string id, int health, int productionQuantity)
            : base(id, health, productionQuantity)
        {
        }

        public virtual void Starve()
        {
            this.Health -= 1;
        }

        public abstract void Eat(IEdible food, int quantity);
    }
}
