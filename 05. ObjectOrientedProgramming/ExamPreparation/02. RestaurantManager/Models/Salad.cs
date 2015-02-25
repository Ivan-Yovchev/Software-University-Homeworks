namespace RestaurantManager.Models
{
    using System;
    using System.Text;
    using RestaurantManager.Interfaces;

    public class Salad : Meal, ISalad
    {
        private const bool DefaultVeganSalad = true;

        private bool containsPasta;

        public Salad(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool containsPasta)
            : base(name, price, calories, quantityPerServing, timeToPrepare, Salad.DefaultVeganSalad)
        {
            this.ContainsPasta = containsPasta;
        }

        public bool ContainsPasta
        {
            get
            {
                return this.containsPasta;
            }
            private set
            {
                this.containsPasta = value;
            }
        }

        public override string ToString()
        {
            StringBuilder salad = new StringBuilder();
            salad
                .Append(base.ToString())
                .AppendLine()
                .AppendFormat("Contains pasta: {0}", this.ContainsPasta ? "yes" : "no");

            return salad.ToString();
        }
    }
}
