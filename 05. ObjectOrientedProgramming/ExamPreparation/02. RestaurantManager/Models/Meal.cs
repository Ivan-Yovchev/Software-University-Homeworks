namespace RestaurantManager.Models
{
    using System;
    using System.Text;
    using RestaurantManager.Interfaces;

    public abstract class Meal : Recipe, IMeal
    {
        private bool isVegan;

        protected Meal(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isVegan)
            : base(name, price, calories, quantityPerServing, timeToPrepare)
        {
            this.IsVegan = isVegan;
        }

        public bool IsVegan
        {
            get
            {
                return this.isVegan;
            }
            private set
            {
                this.isVegan = value;
            }
        }

        public void ToggleVegan()
        {
            if (this.isVegan == true)
            {
                this.isVegan = false;
            }
            else
            {
                this.isVegan = true;
            }
        }

        public override string ToString()
        {
            StringBuilder meal = new StringBuilder();
            meal
                .AppendFormat("{0}", this.IsVegan ? "[VEGAN] " : string.Empty)
                .Append(base.ToString());

            return meal.ToString();
        }
    }
}
