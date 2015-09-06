using System;
using System.Collections.Generic;
using System.Xml;

namespace _05.XPathArtistsAndAlbums
{
    class XpathAtristsAndAlbumsMain
    {
        static void Main()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../catalog.xml");

            string artistsQuery = "/catalog/album/artist";

            Dictionary<string, int> artistsWithNumberOfAlbums =
                new Dictionary<string, int>();

            XmlNodeList artistsList = xmlDoc.SelectNodes(artistsQuery);

            foreach (XmlNode artistNode in artistsList)
            {
                string currArtist = artistNode.InnerText;

                string albumsForArtistQuery =
                    "/catalog/album[artist = \"" + currArtist + "\" ]";

                var albumsForArtistCount =
                    xmlDoc.SelectNodes(albumsForArtistQuery).Count;

                if (!artistsWithNumberOfAlbums.ContainsKey(currArtist))
                {
                    artistsWithNumberOfAlbums.Add(currArtist.Trim(), albumsForArtistCount);
                }
            }

            foreach (var artist in artistsWithNumberOfAlbums)
            {
                Console.WriteLine("Artist: {0}, Albums: {1}", artist.Key, artist.Value);
            }
        }
    }
}
