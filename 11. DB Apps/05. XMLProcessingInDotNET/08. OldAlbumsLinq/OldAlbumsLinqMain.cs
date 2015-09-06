using System;
using System.Linq;
using System.Xml.Linq;

namespace _08.OldAlbumsLinq
{
    class OldAlbumsLinqMain
    {
        static void Main()
        {
            XDocument xmlDoc = XDocument.Load("../../catalog.xml");

            var oldAlbums =
                (from album in xmlDoc.Descendants("album")
                 where Decimal.Parse(album.Element("year").Value) <= (DateTime.Now.Year - 5)
                 select new
                 {
                     Name = album.Element("name").Value,
                     Price = album.Element("price").Value
                 }
                ).ToList();

            foreach (var album in oldAlbums)
            {
                Console.WriteLine("Album: {0}, Price: {1}", album.Name.Trim(), album.Price.Trim());
            }
        }
    }
}
