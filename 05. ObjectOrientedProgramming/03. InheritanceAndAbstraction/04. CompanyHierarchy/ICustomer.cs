using System;
using System.Collections.Generic;

public interface ICustomer : IPerson
{

    decimal PurchaseAmount { get; set; }

}
