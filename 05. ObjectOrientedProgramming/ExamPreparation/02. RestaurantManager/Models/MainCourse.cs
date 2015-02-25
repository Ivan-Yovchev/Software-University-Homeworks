namespace RestaurantManager.Models
{
    using System;
    using System.Text;
    using RestaurantManager.Interfaces;

    public class MainCourse : Meal, IMainCourse
    {
        public MainCourse(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isVegan, string courseType)
            : base(name, price, calories, quantityPerServing, timeToPrepare, isVegan)
        {
            this.Type = (MainCourseType)Enum.Parse(typeof(MainCourseType), courseType);
        }

        public MainCourseType Type { get; private set; }

        public override string ToString()
        {
            StringBuilder mainCourse = new StringBuilder();
            mainCourse
                .Append(base.ToString())
                .AppendLine()
                .AppendFormat("Type: {0}", this.Type);

            return mainCourse.ToString();
        }
    }
}
