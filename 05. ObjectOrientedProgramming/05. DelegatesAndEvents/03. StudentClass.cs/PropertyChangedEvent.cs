using System;

public class PropertyChangedEventArgs : EventArgs
{
    public PropertyChangedEventArgs(string name, string oldValue, string newValue)
    {
        this.PropertyName = name;
        this.OldValue = oldValue;
        this.NewValue = newValue;
    }

    public string PropertyName { get; set; }

    public string OldValue { get; set; }

    public string NewValue { get; set; }
}