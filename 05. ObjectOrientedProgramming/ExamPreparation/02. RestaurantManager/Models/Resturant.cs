namespace RestaurantManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;
    using RestaurantManager.Interfaces;

    public class Resturant : IRestaurant
    {
        private string name;
        private string location;
        private IList<IRecipe> recipes;

        public Resturant(string name, string location)
        {
            this.Name = name;
            this.Location = location;
            this.recipes = new List<IRecipe>();
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
                    throw new ArgumentException("The name of a resturant is required");
                }
                else
                {
                    this.name = value;
                }
            }
        }

        public string Location
        {
            get
            {
                return this.location;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The location of a resturant is required");
                }
                else
                {
                    this.location = value;
                }
            }
        }

        public IList<IRecipe> Recipes
        {
            get
            {
                return this.recipes;
            }
            private set
            {
                this.recipes = value;
            }
        }

        public void AddRecipe(IRecipe recipe)
        {
            this.recipes.Add(recipe);
        }

        public void RemoveRecipe(IRecipe recipe)
        {
            this.recipes.Remove(recipe);
        }

        public string PrintMenu()
        {
            StringBuilder menu = new StringBuilder();
            menu
                .AppendFormat("{0} {1} - {2} {0}", new string('*', 5), this.Name, this.Location);

            if (this.recipes.Count == 0)
            {
                menu.AppendLine().Append("No recipes... yet");
                return menu.ToString();
            }

            var drinks = this.recipes.Where(item => item is Drink);
            menu.Append(GroupRecepies(drinks, "DRINKS"));

            var salads = this.recipes.Where(item => item is Salad);
            menu.Append(GroupRecepies(salads, "SALADS"));

            var mainCourses = this.recipes.Where(item => item is MainCourse);
            menu.Append(GroupRecepies(mainCourses, "MAIN COURSES"));

            var desserts = this.recipes.Where(item => item is Dessert);
            menu.Append(GroupRecepies(desserts, "DESSERTS"));

            return menu.ToString();
        }

        private string GroupRecepies(IEnumerable<IRecipe> recipes, string category)
        {
            if (recipes.Count() == 0)
            {
                return string.Empty;
            }

            StringBuilder buildCategory = new StringBuilder();
            buildCategory.AppendLine().AppendFormat("{0} {1} {0}", new string('~', 5), category);
            recipes = recipes.OrderBy(r => r.Name);
            foreach (var recipe in recipes)
            {
                buildCategory.AppendLine().Append(recipe.ToString());
            }

            return buildCategory.ToString();
        }
    }
}
