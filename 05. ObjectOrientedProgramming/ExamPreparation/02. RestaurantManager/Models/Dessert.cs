namespace RestaurantManager.Models
{
    using System;
    using System.Text;
    using RestaurantManager.Interfaces;

    public class Dessert : Meal, IDessert
    {
        private bool DefaultWithSugar = true;

        public Dessert(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isVegan)
            : base(name, price, calories, quantityPerServing, timeToPrepare, isVegan)
        {
        }

        public bool WithSugar
        {
            get
            {
                return DefaultWithSugar;
            }
        }

        public void ToggleSugar()
        {
            if (DefaultWithSugar == true)
            {
                DefaultWithSugar = false;
            }
            else
            {
                DefaultWithSugar = true;
            }
        }

        public override string ToString()
        {
            StringBuilder dessert = new StringBuilder();
            dessert
                .AppendFormat("{0}", this.WithSugar ? string.Empty : "[NO SUGAR] ")
                .Append(base.ToString());

            return dessert.ToString();
        }
    }
}
