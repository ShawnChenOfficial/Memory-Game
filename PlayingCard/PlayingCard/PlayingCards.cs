using System.Drawing;
using System;

namespace PlayingCard
{
    [Serializable]
    public class PlayingCards
    {
        public CardRank Rank { get; set; }
        public CardSuit Suit { get; set; }
        public int Points { get; set; }
        public bool IsFaceUp { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Abbrev { get; set; }
        public Image FrontImage { get; set; }
        public Image BackImage { get; set; }

        public PlayingCards(CardRank rank, CardSuit suit)
        {
            this.Rank = rank;
            this.Suit = suit;
            this.Points = 0;
            this.FrontImage = null;
            this.BackImage = null;
            this.ID = (int)this.Suit * 13 + (int)this.Rank;
            this.Name = string.Format("{0} of {1}", this.Rank, this.Suit);
            this.Abbrev = GetDefaultAbbrev();
        }

        public string GetDefaultAbbrev()
        {
            string abb = (this.Rank >= CardRank.Two && this.Rank <= CardRank.Nine)
                ? string.Format("{0}{1}", ((int)this.Rank.ToString()[0] + 49), Suit.ToString()[0]) 
                : string.Format("{0}{1}", Rank.ToString()[0], Suit.ToString()[0]);
            return abb;
        }

        public void Flip()
        {
            IsFaceUp = !IsFaceUp;
        }

        public Image GetImage()
        {
            return (IsFaceUp == true) ? FrontImage : BackImage;
        }

        public override string ToString()
        {
            return string.Format("{0}",Name);
        }
    }
}

