using System;
using System.Collections.Generic;
using System.Xml;

namespace _03.AllArtistAlphabetically
{
    class ArtistsAlphabeticallyMain
    {
        static void Main()
        {
            var doc = new XmlDocument();
            doc.Load("../../catalog.xml");
            SortedSet<string> artists = new SortedSet<string>();

            XmlNode rootNode = doc.DocumentElement;

            foreach (XmlNode node in rootNode.ChildNodes)
            {
                artists.Add(node["artist"].InnerText.Trim());
            }

            foreach (var artist in artists)
            {
                Console.WriteLine(artist);
            }
        }
    }
}
