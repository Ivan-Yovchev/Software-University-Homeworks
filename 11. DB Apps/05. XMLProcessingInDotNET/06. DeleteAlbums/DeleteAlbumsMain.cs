using System;
using System.Xml;

namespace _06.DeleteAlbums
{
    class DeleteAlbumsMain
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../catalog.xml");

            XmlNode rootNode = doc.DocumentElement;

            foreach (XmlNode albumNode in rootNode.ChildNodes)
            {
                if (Decimal.Parse(albumNode["price"].InnerText.Trim()) > 20)
                {
                    albumNode.ParentNode.RemoveChild(albumNode);
                }
            }

            doc.Save("../../cheap-albums-catalog.xml");
        }
    }
}
