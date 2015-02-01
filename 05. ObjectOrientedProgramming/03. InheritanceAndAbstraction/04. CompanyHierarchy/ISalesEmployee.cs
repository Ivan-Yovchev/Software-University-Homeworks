using System;
using System.Collections.Generic;

public interface ISalesEmployee : IRegularEmployee
{
    List<ISale> Sales { get; set; }
}
