using System;
using System.Collections.Generic;

public interface IDeveloper : IRegularEmployee
{
    List<IProject> Projects { get; set; }
}
