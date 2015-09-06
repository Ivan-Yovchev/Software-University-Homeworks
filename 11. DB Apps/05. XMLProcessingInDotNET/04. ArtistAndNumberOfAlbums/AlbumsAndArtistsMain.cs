using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace _04.ArtistAndNumberOfAlbums
{
    class AlbumsAndArtistsMain
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../catalog.xml");

            XmlNode rootNode = doc.DocumentElement;

            Dictionary<string, int> artistsWithNumberOfAlbums =
                new Dictionary<string, int>();

            foreach (XmlNode albumNode in rootNode.ChildNodes)
            {
                var currArtist = albumNode["artist"].InnerText.Trim();

                int numberOfalbumsForThisArtist = rootNode.ChildNodes.Cast<XmlNode>()
                    .Count(
                        otherAlbumNode =>
                            otherAlbumNode["artist"].InnerText.Trim() == currArtist);

                if (!artistsWithNumberOfAlbums.ContainsKey(currArtist))
                {
                    artistsWithNumberOfAlbums.Add(currArtist, numberOfalbumsForThisArtist);

                }
            }

            foreach (var artist in artistsWithNumberOfAlbums)
            {
                Console.WriteLine("Artist: {0}, Albums: {1}", artist.Key, artist.Value);
            }

        }
    }
}
