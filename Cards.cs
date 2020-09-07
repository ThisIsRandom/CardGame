using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame
{
    class Deck
    {
        public List<Card> Cards = new List<Card> { };

        private List<string> _CardTypes = new List<string> { "Ruder", "Spar", "Hjerter", "Klør" };

        private int _CardsDrawn = 0;

        public Deck(int amountOfJokers = 0)
        {
            this._CreateDeck();

            if (amountOfJokers > 0) this._AddJokers(amountOfJokers);

            this._Shuffle();
        }

        public Card GetPreviousCard()
        {
            try
            {
                return this.Cards[this._CardsDrawn - 1];
            }
            catch
            {
                return this.Cards[this._CardsDrawn];
            }
        }

        public Card DrawCard()
        {

            this._CardsDrawn++;

            if (this._DeckIsEmpty())
            {
                this._Shuffle();
            }

            return this.Cards[this._CardsDrawn];
        }

        private void _Shuffle()
        {
            Random rnd = new Random();

            this._CardsDrawn = 0;

            this.Cards = this.Cards
                .OrderBy(Card => rnd.Next())
                .ToList();
        }

        private void _AddJokers(int Amount)
        {
            for (int i = 0; i < Amount; i++)
            {
                this.Cards.Add(new Card(0, "Joker"));
            }
        }

        private void _CreateDeck()
        {
            foreach (string CardType in this._CardTypes)
            {
                for (int value = 2; value <= 14; value++)
                {
                    this.Cards
                        .Add(new Card(value, CardType));
                }
            }
        }

        private bool _DeckIsEmpty()
        {
            return this._CardsDrawn >= this.Cards.Count();
        }
    }
}


