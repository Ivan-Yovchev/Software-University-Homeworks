namespace RestaurantManager
{
    using System.Globalization;
    using System.Threading;
    using RestaurantManager.Engine;
    using RestaurantManager.Interfaces;
    using RestaurantManager.Models;

    public class RestaurantManagementProgram
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            RestaurantManagerEngine.Instance.Start();
        }
    }
}