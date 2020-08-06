using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayingCard;

namespace test
{
    class Program
    {
        public static void Main(string[] args)
        {
            Deck deck = new Deck(CardRank.Ace, CardRank.Two);

            foreach (PlayingCards card in deck.cards)
            {
                Console.WriteLine(card.ID);

                Console.ReadLine();
            }
        }
    }
}
