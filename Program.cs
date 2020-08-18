using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack2CS
{
    class Hand
    {
        public List<Card> Cards = new List<Card>();
        public int TotalValue()
        {
            var total = 0;

            foreach (var card in Cards)
            {
                total = total + card.Value();
            }
            return total;
        }



        public bool Busted()
        {
            if (TotalValue() > 21)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Display()
        {

            foreach (var card in Cards)
            {
                Console.WriteLine($"The {card.Face} of {card.Suit}");
            }
            Console.WriteLine($"The total is: {TotalValue()}");
            Console.WriteLine();
        }
        public void AddCardToHand(Card cardToAdd)
        {
            Cards.Add(cardToAdd);
        }
    }


    class Card
    {
        public string Face { get; set; }

        public string Suit { get; set; }

        public int Value()
        {
            var answer = 0;
            // GROUP LIKE CASES  EX 1-10...J Q K 
            switch (Face)
            {
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case "10":
                    answer = int.Parse(Face);
                    break;

                case "Jack":
                case "Queen":
                case "King":
                    answer = 10;
                    break;

                case "Ace":
                    answer = 1;
                    break;
            }

            return answer;
        }
    }
    class Deck
    {
        public List<Card> CardsInDeck = new List<Card>();

        public Card DealCard()
        {
            var topCard = CardsInDeck[0];
            CardsInDeck.Remove(topCard);

            return topCard;
        }
        public void ShuffleCards()
        {
            // DECK CREATION
            var suits = new List<string>() { "Diamonds", "Clubs", "Spades", "Hearts" };
            var faces = new List<string>() { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };

            foreach (var suit in suits)
            {

                foreach (var face in faces)
                {
                    var ourCard = new Card()
                    {
                        Face = face,
                        Suit = suit,
                    };

                    CardsInDeck.Add(ourCard);
                }
            }

            // SHUFFLE 

            var randomCardGenerator = new Random();


            var n = CardsInDeck.Count();


            for (var rightIndex = n - 1; rightIndex > 0; rightIndex--)
            {


                var leftIndex = randomCardGenerator.Next(rightIndex);

                var leftCard = CardsInDeck[rightIndex];

                var rightCard = CardsInDeck[leftIndex];

                CardsInDeck[rightIndex] = rightCard;

                CardsInDeck[leftIndex] = leftCard;
            }
        }

    }

    class Program
    {
        static void DisplayGreeting()
        {
            //GREETING CODE
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("    Welcome to BLACKJACK!!!    ");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
            System.Threading.Thread.Sleep(2000);
        }
        static void DealCards()
        {
            // DEAL CARDS ANNOUNCEMENT
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("    Dealing Cards!    ");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
            System.Threading.Thread.Sleep(1000);

        }
        static string PromptForString(string prompt)
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine();
            return userInput;
        }
        static int PromptForInteger(string prompt)
        {
            Console.Write(prompt);
            var userInput = int.Parse(Console.ReadLine());
            return userInput;
        }
        static void Main(string[] args)

        {

            // GREETING
            DisplayGreeting();




            var playAgain = "YES";

            while (playAgain.ToUpper() == "YES")
            {
                DealCards();

                // CREATE DECK AND SHUFFLE CARDS
                var deck = new Deck();
                deck.ShuffleCards();
                // CREATE PLAYER AND DEALER HANDS
                var player = new Hand();

                var dealer = new Hand();
                // REMOVE CARD FROM DECK
                for (var count = 0; count < 2; count++)
                {
                    player.AddCardToHand(deck.DealCard());
                }

                for (var count = 0; count < 2; count++)
                {
                    dealer.AddCardToHand(deck.DealCard());
                }
                // CHECK FOR BUST SCENARIO
                var choice = "";
                while (choice != "STAND" && !player.Busted())
                {
                    Console.WriteLine("||------- PLAYER HAND -------||");
                    player.Display();
                    // HIT OR STAND QUESTION
                    Console.WriteLine();
                    Console.Write("HIT or STAND? ");
                    choice = Console.ReadLine();
                    //HIT
                    if (choice == "HIT")
                    {

                        player.AddCardToHand(deck.DealCard());
                    }
                    //STAND
                }

                Console.WriteLine("||------- PLAYER HAND -------||");
                player.Display();

                //WHILE LOOP FOR PLAYER BUST
                while (!player.Busted() && dealer.TotalValue() < 17)
                {
                    //CHECK DEALER TOTAL < 17
                    dealer.AddCardToHand(deck.DealCard());
                }

                Console.WriteLine("||------- DEALER HAND -------||");
                dealer.Display();

                //REVEAL DEALER HAND
                //PLAYER BUST?
                if (player.Busted())
                {
                    Console.WriteLine("||----PLAYER BUSTS!!!----||");
                    Console.WriteLine("Dealer wins!!!!");
                }
                else
                {
                    // DEALER BUST?
                    if (dealer.Busted())
                    {
                        Console.WriteLine("||----DEALER BUSTS!!!----||");
                        Console.WriteLine("Player wins!!!!");
                    }
                    else
                    {

                        if (dealer.TotalValue() > player.TotalValue())
                        {
                            Console.WriteLine("Dealer Wins!");
                        }
                        else
                        {
                            if (player.TotalValue() > dealer.TotalValue())
                            {
                                Console.WriteLine("Player wins");
                            }
                            else
                            {
                                Console.WriteLine("Tie goes to the dealer");

                            }
                        }
                    }
                }

                Console.WriteLine();
                Console.Write("Play again? YES or NO? ");
                playAgain = Console.ReadLine();
            }
        }
    }
}




