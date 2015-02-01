using System;
using System.Collections.Generic;

public interface IProject
{
    string ProjectName { get; set; }

    string Details { get; set; }

    DateTime StartDate { get; set; }

    State State { get; set; }

    void CloseProject();

}

