using System;

static class HTMLDispatcher
{

    public static ElementBuilder CreateImage(string source, string alt, string title)
    {
        ElementBuilder image = new ElementBuilder("img");
        image.AddAtribute("src", source);
        image.AddAtribute("alt", alt);
        image.AddAtribute("title", title);

        return image;
    }

    public static ElementBuilder CreateURL(string url, string title, string text)
    {
        ElementBuilder aTag = new ElementBuilder("a");
        aTag.AddAtribute("href", url);
        aTag.AddAtribute("title", title);
        aTag.AddContent(text);

        return aTag;
    }

    public static ElementBuilder CreateInput(string input, string name, string value)
    {
        ElementBuilder inputTag = new ElementBuilder("input");
        inputTag.AddAtribute("type", input);
        inputTag.AddAtribute("name", name);
        inputTag.AddAtribute("value", value);

        return inputTag;
    }

}
