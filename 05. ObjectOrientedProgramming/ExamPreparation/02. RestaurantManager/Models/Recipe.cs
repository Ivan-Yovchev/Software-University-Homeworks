namespace RestaurantManager.Models
{
    using System;
    using System.Text;
    using RestaurantManager.Interfaces;

    public abstract class Recipe : IRecipe
    {
        private const MetricUnit DefaultMetricUnit = MetricUnit.Grams;

        private string name;
        private decimal price;
        protected int calories;
        private int quantityPerServing;
        protected int timeToPrepare;

        protected Recipe(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare)
        {
            this.Name = name;
            this.Price = price;
            this.Calories = calories;
            this.QuantityPerServing = quantityPerServing;
            this.TimeToPrepare = timeToPrepare;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The name of a recipe is required");
                }
                else
                {
                    this.name = value;
                }
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The price of a recipe must be positive");
                }
                else
                {
                    this.price = value;
                }
            }
        }

        public virtual int Calories
        {
            get
            {
                return this.calories;
            }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The calories of a recipe must be positive");
                }
                else
                {
                    this.calories = value;
                }
            }
        }

        public int QuantityPerServing
        {
            get
            {
                return this.quantityPerServing;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The quantity per serving of a recipe must be positive");
                }
                else
                {
                    this.quantityPerServing = value;
                }
            }
        }

        public virtual MetricUnit Unit
        {
            get
            {
                return DefaultMetricUnit;
            }
        }

        public virtual int TimeToPrepare
        {
            get
            {
                return this.timeToPrepare;
            }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The time to prepare of a recipe must be positive");
                }
                else
                {
                    this.timeToPrepare = value;
                }
            }
        }

        public override string ToString()
        {
            string unit = string.Empty;
            switch (this.Unit)
            {
                case MetricUnit.Milliliters: unit += "ml"; break;
                case MetricUnit.Grams: unit += "g"; break;
            }

            StringBuilder recipe = new StringBuilder();
            recipe
                .AppendFormat("==  {0} == ${1:F2}", this.Name, this.Price)
                .AppendLine()
                .AppendFormat("Per serving: {0} {1}, {2} kcal", this.QuantityPerServing, unit, this.Calories)
                .AppendLine()
                .AppendFormat("Ready in {0} minutes", this.TimeToPrepare);

            return recipe.ToString();
        }
    }
}
