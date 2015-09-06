using System;
using System.Xml;

namespace _07.OldAlbums
{
    class Program
    {
        static void Main()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../catalog.xml");

            int yearAfter5Years = DateTime.Now.Year - 5;

            string albumsQuery =
                "/catalog/album[year <= " + yearAfter5Years + "]";

            XmlNodeList albumsList = xmlDoc.SelectNodes(albumsQuery);

            foreach (XmlNode album in albumsList)
            {
                Console.WriteLine("Album: {0}, Price: {1}",
                    album["name"].InnerText.Trim(), album["price"].InnerText.Trim());
            }
        }
    }
}
