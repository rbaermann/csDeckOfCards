using System;
using System.Collections.Generic;

namespace deckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck newDraw = new Deck();
            Player Ryan = new Player("Ryan");
            System.Console.WriteLine("==================================DRAWING CARDS==================================");
            System.Console.WriteLine();
            Ryan.draw(newDraw);
            Ryan.draw(newDraw);
            Ryan.draw(newDraw);
            Ryan.draw(newDraw);
            Ryan.draw(newDraw);
            Ryan.draw(newDraw);
            Ryan.draw(newDraw);
            System.Console.WriteLine($"Your Hand has {Ryan.hand.Count} Cards");
            System.Console.WriteLine();
            System.Console.WriteLine("Your Hand Contains the Following Cards: ");
            foreach(var card in Ryan.hand) {
                System.Console.WriteLine($"{card.stringVal} of {card.suit}");
            }
            System.Console.WriteLine();
            Ryan.discard(1);
            Ryan.discard(2);
            Ryan.discard(3);
            System.Console.WriteLine($"Your Hand has {Ryan.hand.Count} Cards");
            System.Console.WriteLine("Your Hand Contains the Following Cards: ");
            foreach(var card in Ryan.hand) {
                System.Console.WriteLine($"{card.stringVal} of {card.suit}");
            }
        }

        public class Card {
            public string stringVal;
            public string suit;
            public int val;

            public Card(string name, string suitType, int value) {
                stringVal = name;
                suit = suitType;
                val = value;
            }
        }

        public class Deck {
            public List<Card> cards;

            public Deck() {
                reset();
                Shuffle();
            }

            public Deck reset() {
                cards = new List<Card>();
                string[] suits = {"Hearts", "Diamonds", "Clubs", "Spades"};
                string[] stringVal = {"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"};

                foreach(string suit in suits) {
                    for(int i = 0; i < stringVal.Length; i++) {
                        Card newDeck = new Card(stringVal[i], suit, i+1);
                        cards.Add(newDeck);
                    }
                }
                return this;
            }

            public Deck Shuffle() {
                Random rand = new Random();
                int i = cards.Count-1;
                while(i > 0) {
                    int j = rand.Next(i + 1);
                    Card temp = cards[j];
                    cards[j] = cards[i];
                    cards[i] = temp;
                    i--;
                }
                return this;
            }

            public Card deal() {
                while(cards.Count > 0) {
                    Card top = cards[0];
                    cards.RemoveAt(0);
                    return top;
                }
                reset();
                return deal();
            }
        }

        public class Player {
            string name;
            public List<Card> hand;

            public Player(string person) {
                name = person;
                hand = new List<Card>();
            }   

            public Card draw(Deck playerDeck) {
                Card newDeck = playerDeck.deal();
                hand.Add(newDeck);
                return newDeck;
            }

            public Card discard(int i) {
                if(i < 0 || i > hand.Count) {
                    return null;
                }
                else {
                    Card res = hand[i];
                    hand.RemoveAt(i);
                    return res;
                }
            }
        }
    }
}
