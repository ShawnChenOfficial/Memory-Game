using System.Collections.Generic;
using System;
using System.Drawing;
using System.Linq;

namespace PlayingCard
{
    [Serializable]
    public class Deck
    {
        public static Random rnd = new Random();

        public List<PlayingCards> cards = new List<PlayingCards>();

        public Deck(params CardRank[] ranks)
        //public Deck()
        {
            for (CardSuit suit = CardSuit.Clubs; suit <= CardSuit.Spades; suit++)
            {
                for (CardRank rank = CardRank.Ace; rank <= CardRank.King; rank++)
                {
                    if (ranks.Length == 0 || ranks.Contains(rank)) {
                    cards.Add(new PlayingCards(rank, suit));
                    }
                }
            }
        }

        public bool IsEmpty()
        {
            return (cards.Count == 0) ? true : false;
        }

        public PlayingCards DealTopCard()
        {
            return (cards.Count == 0) ? null : Swap();
        }

        public PlayingCards Swap()
        {
            PlayingCards card = cards[0];
            cards.RemoveAt(0);
            return card;
        }

        public void Shuffle()
        {
            for (int i = cards.Count - 1; i > 1; i--)
            {
                int pos = rnd.Next(i);
                PlayingCards tmp = cards[i];
                cards[i] = cards[pos];
                cards[pos] = tmp;
            }
        }

        public void AssignImage(List<Image> faces, Image back)
        {
            if (faces.Count != cards.Count) throw new Exception("Size Is Not Matching");

            for (int i = 0; i < faces.Count; i++)
            {
                cards[i].FrontImage = faces[i];
                cards[i].BackImage = back;
            }
        }
    }
}
