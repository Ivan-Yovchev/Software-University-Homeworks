using System;
using System.Xml;

namespace _02.ExtractAlbumNames
{
    class ExtractAlbumNamesMain
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../catalog.xml");

            XmlNode rootNode = doc.DocumentElement;

            foreach (XmlNode childNode in rootNode.ChildNodes)
            {
                Console.WriteLine("Album -> {0}", childNode["name"].InnerText.Trim());
            }
        }
    }
}
