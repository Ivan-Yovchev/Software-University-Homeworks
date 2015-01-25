using System;

class ElementBuilder
{
    private string name;

    public string Name 
    {
        get { return this.name; }
        set { this.name = value; } 
    }

    public ElementBuilder(string name)
    {
        this.Name = "<" + name + "></" + name + ">";
    }

    public string AddAtribute(string attribute, string value)
    {
        string addAtr = this.name.Substring(0, this.name.IndexOf(">")) + " " + attribute
            + "=\"" + value + "\"" 
            + this.name.Substring(this.name.IndexOf(">"), this.name.Length - this.name.IndexOf(">"));

        this.name = addAtr;

        return addAtr;
    }

    public string AddContent(string value)
    {
        string addCont = this.name.Substring(0, this.name.IndexOf(">") + 1)
            + value
            + this.name.Substring(this.name.IndexOf(">") + 1, this.name.Length - this.name.IndexOf(">") - 1);

        this.name = addCont;

        return addCont;

    }

    public static string operator *(ElementBuilder element, int number)
    {
        string result = "";
        for (int i = 0; i < number; i++)
        {
            result += element;
        }

        return result;
    }

    public override string ToString()
    {
        return this.name;
    }

}
