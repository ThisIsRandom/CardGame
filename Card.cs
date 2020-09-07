using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CardGame
{
    class Card
    {
        private int Value;
        public string Type;

        public Card(int value, string type)
        {
            this.Value = value;
            this.Type = type;
        }

        public string getSymbolicValue()
        {
            if (this.Value > 10)
            {
                switch (this.Value)
                {
                    case 0:
                        return "Joker";
                    case 11:
                        return "Bonde";
                    case 12:
                        return "Dronning";
                    case 13:
                        return "Konge";
                    case 14:
                        return "Es";
                }
            }

            return this.Value.ToString();
        }

        public int getValue()
        {
            return this.Value;
        }
    }
}