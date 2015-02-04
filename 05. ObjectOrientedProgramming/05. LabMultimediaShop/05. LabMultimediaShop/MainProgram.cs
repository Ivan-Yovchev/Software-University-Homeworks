using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabMultimediaShop.Engine;
using LabMultimediaShop.Items;
using LabMultimediaShop.RentAndSale;

namespace LabMultimediaShop
{
    class MainProgram
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            ShopEngine engine = new ShopEngine();
            engine.Run();
        }
    }
}
