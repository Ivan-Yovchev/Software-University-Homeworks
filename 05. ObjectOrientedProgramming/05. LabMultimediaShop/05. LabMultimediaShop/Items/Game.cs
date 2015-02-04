using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LabMultimediaShop.Items
{
    public class Game : Item
    {
        private AgeRestriction ageRestriction;

        public Game(string id, string title, decimal price, List<string> genres, AgeRestriction ageRestriction = AgeRestriction.Minor)
            : base(id, title, price, genres)
        {
            this.AgeRestriction = AgeRestriction;
        }

        public Game(string id, string title, decimal price, string genre, AgeRestriction ageRestriction = AgeRestriction.Minor)
            : base(id, title, price, new List<string>() { genre })
        {
            this.AgeRestriction = AgeRestriction;
        }

        public AgeRestriction AgeRestriction
        {
            get
            {
                return this.ageRestriction;
            }
            set
            {
                this.ageRestriction = value;
            }
        }

        public override string ToString()
        {
            string result = string.Format("Game {0}Age Restriction: {1}\n", base.ToString(), this.ageRestriction);

            return result;
        }
    }
}
