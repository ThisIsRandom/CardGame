using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace CardGame
{
    class Players
    {
        public List<Player> ListOfPlayers = new List<Player> { };

        public Player ActivePlayer;


        public Players(string[] Names)
        {
            foreach (string Name in Names)
            {
                this.ListOfPlayers.Add(new Player(Name));
            }

            this.ActivePlayer = this.ListOfPlayers[0];

        }

        public void ChangeActivePlayer(string Who = null)
        {

            if (Who != null)
            {
                this.ActivePlayer = this.ListOfPlayers[this.ListOfPlayers.FindIndex(P => P.Name == Who)];
                return;
            }

            if (this.ListOfPlayers.IndexOf(this.ActivePlayer) >= this.ListOfPlayers.Count - 1)
            {
                this.ActivePlayer = this.ListOfPlayers[0];
                return;

            }

            this.ActivePlayer = this.ListOfPlayers[this.ListOfPlayers.IndexOf(this.ActivePlayer) + 1];

        }
    }
}
