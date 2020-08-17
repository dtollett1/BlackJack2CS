using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJackCS
{
    class card
    {
        public string Suit { get; set; }
        public string Face { get; set; }
        public int Value()
        {
            switch (Face)
            {
                case "Ace":
                    return 1;
                case "2":
                    return 2;
                case "3":
                    return 3;
                case "4":
                    return 4;
                case "5":
                    return 5;
                case "6":
                    return 6;
                case "7":
                    return 7;
                case "8":
                    return 8;
                case "9":
                    return 9;
                case "10":
                    return 10;
                case "Jack":
                    return 10;
                case "Queen":
                    return 10;
                case "King":
                    return 10;
                default:
                    return 0;



            }
        }


    }
    class Player
    {
        public string Name { get; set; }

        public List<card> Hand = new List<card>();
        public int Score { get; set; }
        public int PlayerScore()
        {
            int scoreTotal = 0;
            foreach (card cardInHand in Hand)
            {
                scoreTotal = scoreTotal + cardInHand.Value();

            }
            return scoreTotal;

        }
    }
    class Program
    {
        static void DisplayGreeting()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("    Welcome to BLACKJACK!!!    ");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
            System.Threading.Thread.Sleep(2000);
        }
        static void DealCards()
        {
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
            DisplayGreeting();


            var deal = PromptForString("Deal cards?");

            if (deal == "yes")
            {
                // Deck Creation
                var deck = new List<card>();

                var newFace = new string[] { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
                var newSuit = new string[] { "Diamonds", "Clubs", "Spades", "Hearts" };

                for (var suitIndex = 0; suitIndex < newSuit.Length; suitIndex++)
                {
                    for (var faceIndex = 0; faceIndex < newFace.Length; faceIndex++)
                    {
                        string cardSuit = newSuit[suitIndex];
                        string cardFace = newFace[faceIndex];
                        var newCard = new card();

                        {
                            newCard.Suit = cardSuit;
                            newCard.Face = cardFace;

                        }

                        deck.Add(newCard);
                    }

                    // Shuffler

                    var randomCardGenerator = new Random();


                    var cardsInDeck = deck.Count;



                    for (var rightIndex = cardsInDeck - 1; rightIndex > 0; rightIndex--)
                    {


                        var leftIndex = randomCardGenerator.Next(rightIndex);

                        var leftCard = deck[rightIndex];

                        var rightCard = deck[leftIndex];

                        deck[rightIndex] = rightCard;

                        deck[leftIndex] = leftCard;

                    }



                }



                var dealer = new Player();
                {
                    dealer.Name = "Dealer";
                }

                var player1 = new Player();
                {
                    player1.Name = "Player One";


                }

                player1.Hand.Add(deck[0]);
                player1.Hand.Add(deck[1]);

                deck.RemoveAt(0);
                deck.RemoveAt(0);


                dealer.Hand.Add(deck[0]);
                dealer.Hand.Add(deck[1]);

                deck.RemoveAt(0);
                deck.RemoveAt(0);

                DealCards();


                foreach (var playerCard in player1.Hand)
                {
                    Console.WriteLine($" You have Been Dealt {playerCard.Face} of {playerCard.Suit} with value of {playerCard.Value()}");

                }

                var hit = true;
                // var answer = PromptForString($" Your Total is {player1.PlayerScore()} Hit?");
                while (hit == true)
                {
                    var answer = PromptForString($"Your Total is {player1.PlayerScore()}  Hit?");

                    hit = (answer == "hit");
                    player1.Hand.Add(deck[0]);
                    deck.RemoveAt(0);
                    foreach (var playerCard in player1.Hand)
                    {
                        Console.WriteLine($" You have Been Dealt {playerCard.Face} of {playerCard.Suit} with value of {playerCard.Value()}");


                    }
                    if (player1.PlayerScore() > 21)
                    {
                        Console.WriteLine("Player One BUST!");
                        break;
                    }
                    else
                    {
                        foreach (var dealerCard in dealer.Hand)
                        {
                            Console.WriteLine($" Dealer has been dealt {dealerCard.Face} of {dealerCard.Suit} with value of {dealerCard.Value()}");

                        }
                    }




                }




                // while (hit == true)
                // {


//     player1.Hand.Add(deck[0]);
//     deck.RemoveAt(0);


//     if (player1.PlayerScore() > 21)
//     {
//         Console.WriteLine("Player One BUST!");
//         break;


//     }
//     else
//     {
//         foreach (var playerCard in player1.Hand)
//         {
//             answer = PromptForString($" You have Been Dealt {playerCard.Face} of {playerCard.Suit} with value of {playerCard.Value()} Your Total is {player1.PlayerScore()}  Hit or Stay?");
//             hit = (answer == "hit");

//             player1.Hand.Add(deck[0]);
//             deck.RemoveAt(0);
//             if (player1.PlayerScore() > 21)
//             {
//                 Console.WriteLine("Player One BUST!");
//                 break;



//             }
//             break;
//         }

//     }