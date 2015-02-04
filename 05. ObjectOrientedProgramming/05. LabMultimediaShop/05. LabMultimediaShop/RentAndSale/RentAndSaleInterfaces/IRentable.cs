using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabMultimediaShop.Items;


namespace LabMultimediaShop.RentAndSale
{
    public interface IRentable
    {
        IItem Item { get; set; }

        RentStatus RentState { get; set; }

        DateTime RentDate { get; set; }

        DateTime Deadline { get; set; }

        DateTime ReturnDate { get; set; }

        decimal RentFine { get; }

        void ReturnItem();
    }
}
