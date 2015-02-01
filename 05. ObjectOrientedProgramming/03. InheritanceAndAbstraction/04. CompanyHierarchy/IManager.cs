using System;
using System.Collections.Generic;

public interface IManager : IEmployee
{
    List<Employee> Employees { get; set; }
}
