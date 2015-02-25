namespace RestaurantManager.Models
{
    using System;
    using System.Text;
    using RestaurantManager.Interfaces;

    public class Drink : Recipe, IDrink
    {
        private const MetricUnit DefaultDrinkMetricUnit = MetricUnit.Milliliters;

        private bool isCarbonated;

        public Drink(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isCarbonated)
            : base(name, price, calories, quantityPerServing, timeToPrepare)
        {
            this.IsCarbonated = isCarbonated;
        }

        public bool IsCarbonated
        {
            get
            {
                return this.isCarbonated;
            }
            private set
            {
                this.isCarbonated = value;
            }
        }

        public override int Calories
        {
            get
            {
                return base.Calories;
            }
            protected set
            {
                if (value > 100)
                {
                    throw new ArgumentException("The calories of a drink must not be greater than 100");
                }
                else
                {
                    base.calories = value;
                }
            }
        }

        public override int TimeToPrepare
        {
            get
            {
                return base.TimeToPrepare;
            }
            protected set
            {
                if (value > 20)
                {
                    throw new ArgumentException("The time to prepare of a drink must be less than 20");
                }
                else
                {
                    base.timeToPrepare = value;
                }
            }
        }

        public override MetricUnit Unit
        {
            get
            {
                return DefaultDrinkMetricUnit;
            }
        }

        public override string ToString()
        {
            StringBuilder drink = new StringBuilder();
            drink
                .Append(base.ToString())
                .AppendLine()
                .AppendFormat("Carbonated: {0}", this.IsCarbonated ? "yes" : "no");

            return drink.ToString();
        }
    }
}
