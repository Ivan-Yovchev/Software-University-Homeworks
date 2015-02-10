using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabMultimediaShop.Items;


namespace LabMultimediaShop.RentAndSale
{
    public interface ISaleable
    {
        IItem Item { get; set; }

        DateTime SaleDate { get; set; }
    }
}
