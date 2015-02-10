using System;

class VersionAttribute : System.Attribute
{
    public int Major { get; private set; }
    public int Minor { get; private set; }

    public VersionAttribute(int major, int minor)
	{
		this.Major = major;
        this.Minor = minor;
	}

    public override string ToString()
    {
        return this.Major + "." + this.Minor;
    }
}
