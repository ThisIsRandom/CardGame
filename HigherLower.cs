using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    class HigherLower
    {
        public Deck Deck;
        public Score Score;
        public Players Players;

        public HigherLower()
        {

            this.Deck = new Deck();
            this.Score = new Score();
            this.Players = this._CreatePlayers();

            //Mangler mulighed for at quitte

            while (true)
            {
                this._PlayRound();
            }

        }

        private void _PlayRound()
        {
            if (this.Score.getScore() % 4 == 0 && this.Score.getScore() >= 4)
            {
                this._PassTurn();
            }

            Player Player = this._GetActivePlayer();

            Card NewCard = this.Deck.DrawCard();

            Card PreviousCard = this.Deck.GetPreviousCard();

            Console.WriteLine(PreviousCard.Type + " " + PreviousCard.getSymbolicValue());

            this._EvalCards(PreviousCard, NewCard, Player);

            Console.WriteLine(NewCard.Type + " " + NewCard.getSymbolicValue());

            Console.ReadLine();

            Console.Clear();

        }

        private Players _CreatePlayers()
        {
            Console.WriteLine("Hvor mange spillere? ");

            try
            {
                int input = Convert.ToInt32(Console.ReadLine());
                string[] Names = new string[input];

                for (int i = 0; i < input; i++)
                {
                    Console.WriteLine($"Navn på Spiller {i + 1} :");
                    Names[i] = Console.ReadLine();
                }

                Console.Clear();
                return new Players(Names);
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Noget er gået galt.. Måske du ikke indtastede et tal ved mængden af spillere?? ");
                return this._CreatePlayers();
            }
        }


        private void _EvalCards(Card PrevCard, Card NewCard, Player CurPlayer)
        {
            Console.WriteLine("Højere eller Lavere?  [ H / L]");

            bool Guess = Console.ReadLine().ToLower() == "h";

            bool isBigger = PrevCard.getValue() <= NewCard.getValue();

            if (Guess == isBigger || NewCard.getValue() == 0)
            {
                Console.WriteLine("Korrekt");
                this.Score.Add();
                return;
            }

            Console.WriteLine("Forkert");
            Console.WriteLine(this.Score.getScore() + " armbøjning til " + CurPlayer.Name);
            this.Score.Reset();
            this.Players.ChangeActivePlayer();

        }

        private void _PassTurn()
        {
            Console.WriteLine("Du skal give turen videre");

            Console.WriteLine("Muligheder: ");

            this.Players.ListOfPlayers.ForEach(P => Console.WriteLine(P.Name));

            this.Players.ChangeActivePlayer(Console.ReadLine());

            Console.Clear();
        }

        private Player _GetActivePlayer()
        {

            Console.WriteLine(this.Players.ActivePlayer.Name.ToUpper() + "'s tur: ");

            return this.Players.ActivePlayer;
        }
    }
}

