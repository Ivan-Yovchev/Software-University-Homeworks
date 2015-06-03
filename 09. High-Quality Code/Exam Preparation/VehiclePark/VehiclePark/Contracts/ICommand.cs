using System.Collections.Generic;

namespace VehiclePark.Contracts
{
    public interface ICommand
    {
        string CommandName { get; } 
        IDictionary<string, string> Parameters { get; }
    }
}
