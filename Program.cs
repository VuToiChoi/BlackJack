using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Card> deckList = new List<Card>();
            Deck deck = new Deck(deckList);
            List<Card> playerCards = new List<Card>();
            List<Card> dealersCards = new List<Card>();
            bool run = true;

            Console.WriteLine("Välkomen till Black Jack spel");
            int gameStatus = 9;

            while (run)
            {
                if (gameStatus == 9)
                {
                    if (playerCards.Count != 0)
                    {
                        for (int i = playerCards.Count; i > 0; i--)
                        {
                            deckList.Add(playerCards[0]);
                            playerCards.RemoveAt(0);
                        }
                        for (int i = dealersCards.Count; i > 0; i--)
                        {
                            deckList.Add(dealersCards[0]);
                            dealersCards.RemoveAt(0);
                        }
                        gameStatus = 9;
                    }
                    else
                    {
                        try
                        {
                            deck.AddCard();
                            Console.Write("1. Spela\n0. Exit\n--> ");
                            gameStatus = int.Parse(Console.ReadLine());
                            deck.ShuffleCardDeck();
                            playerCards.Add(deck.GetFirstCard());
                            dealersCards.Add(deck.GetFirstCard());
                            playerCards.Add(deck.GetFirstCard());
                            dealersCards.Add(deck.GetFirstCard());
                        }
                        catch (Exception e)
                        {
                            Console.Clear();
                            Console.WriteLine("do ngu do an hai co cai nut cung bam sai dc?");
                            Console.WriteLine("-------------------------------------");
                            continue;
                        }
                    }
                }
                else if (gameStatus == 0)
                {
                    run = false;
                }
                else if (gameStatus == 1)
                {
                    Console.Clear();
                    PrintDealerAndPlayerPoint(dealersCards, playerCards, 1000);



                    Console.Write("1. Hit\n2. Stand\n--> ");
                    int playerChoice = int.Parse(Console.ReadLine());

                    if (playerChoice == 1)
                    {
                        playerCards.Add(deck.GetFirstCard());
                        Console.Clear();
                        Console.WriteLine("Ditt kort:");
                        for (int i = 0; i < playerCards.Count; i++)
                        {

                            Console.WriteLine(playerCards[i]._cardName + "|" + playerCards[i]._cardType + "|" + playerCards[i]._cardPoint);
                        }
                        int playerPoint = GetPlayerPoint(playerCards);
                        Console.WriteLine("Ditt poäng: " + playerPoint);
                        Console.WriteLine("-------------------------------------");

                        if (playerPoint > 21)
                        {
                            Console.WriteLine("Du förlorade.");
                            gameStatus = 9;
                        }
                        else if (playerPoint == 21)
                        {
                            playerChoice = 2;
                        }
                    }
                    else if (playerChoice == 2)
                    {
                        int playerPoint = GetPlayerPoint(playerCards);
                        int dealerPoint = GetDealerPoint(dealersCards);
                        PrintDealerAndPlayerPoint(dealersCards, playerCards, playerChoice);
                        while (dealerPoint < 17)
                        {
                            dealersCards.Add(deck.GetFirstCard());
                            dealerPoint = GetDealerPoint(dealersCards);
                            if (dealerPoint >= 17)
                            {
                                Console.Clear();
                                PrintDealerAndPlayerPoint(dealersCards, playerCards, playerChoice);
                                break;
                            }
                        }
                        if (dealerPoint >= 17 && dealerPoint <= 21)
                        {
                            if (dealerPoint == playerPoint && dealerPoint < 19 && playerPoint < 19)
                            {
                                Console.WriteLine("Du förlorade");
                            }
                            else if (playerPoint == dealerPoint && dealerPoint > 19 && playerPoint > 19)
                            {
                                Console.WriteLine("Lika");
                            }
                            else if (playerPoint > dealerPoint)
                            {
                                Console.Write("Du vann");
                            }
                            else
                            {
                                Console.WriteLine("Du förlorade");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Du vann");
                        }
                        Console.WriteLine("\nPress any key to restart...");
                        Console.ReadKey();
                        gameStatus = 9;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("do ngu do an hai co cai nut cung bam sai dc?");
                    Console.WriteLine("-------------------------------------");
                    gameStatus = 9;
                }
            }
        }

        static int GetPlayerPoint(List<Card> playerCard)
        {
            int playerPoint = 0;
            for (int i = 0; i < playerCard.Count; i++)
            {
                if (playerCard[i]._cardName != "Ace")
                {
                    playerPoint = playerCard[i]._cardPoint + playerPoint;
                }
            }
            for (int i = 0; i < playerCard.Count; i++)
            {
                if (playerCard[i]._cardName == "Ace")
                {
                    if (playerPoint <= 10)
                    {
                        playerCard[i]._cardPoint = 11;
                        playerPoint = playerCard[i]._cardPoint + playerPoint;
                    }
                    else
                    {
                        playerCard[i]._cardPoint = 1;
                        playerPoint = playerCard[i]._cardPoint + playerPoint;
                    }
                }
            }
            return playerPoint;
        }

        static int GetDealerPoint(List<Card> dealerCard)
        {
            int dealerPoint = 0;
            for (int i = 0; i < dealerCard.Count; i++)
            {
                if (dealerCard[i]._cardName != "Ace")
                {
                    dealerPoint = dealerCard[i]._cardPoint + dealerPoint;
                }
            }
            for (int i = 0; i < dealerCard.Count; i++)
            {
                if (dealerCard[i]._cardName == "Ace")
                {
                    if (dealerPoint <= 10)
                    {
                        dealerCard[i]._cardPoint = 11;
                        dealerPoint = dealerCard[i]._cardPoint + dealerPoint;
                    }
                    else
                    {
                        dealerCard[i]._cardPoint = 1;
                        dealerPoint = dealerCard[i]._cardPoint + dealerPoint;
                    }
                }
            }
            return dealerPoint;
        }
        static void PrintDealerAndPlayerPoint(List<Card> dealersCards, List<Card> playerCards, int playerChoice)
        {
            if (playerChoice != 2)
            {
                Console.WriteLine("Ditt kort:");
                for (int i = 0; i < playerCards.Count; i++)
                {

                    Console.WriteLine(playerCards[i]._cardName + "|" + playerCards[i]._cardType + "|" + playerCards[i]._cardPoint);
                }
                int playerPoint = GetPlayerPoint(playerCards);
                Console.WriteLine("Ditt poäng: " + playerPoint);
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Dealers kort:");
                Console.WriteLine(dealersCards[0]._cardName + "|" + dealersCards[0]._cardType + "|" + dealersCards[0]._cardPoint + "\n * * *");
                Console.WriteLine("Dealers poäng: " + dealersCards[0]._cardPoint);
                Console.WriteLine("-------------------------------------");
            }
            else
            {
                Console.WriteLine("Ditt kort:");
                for (int i = 0; i < playerCards.Count; i++)
                {

                    Console.WriteLine(playerCards[i]._cardName + "|" + playerCards[i]._cardType + "|" + playerCards[i]._cardPoint);
                }
                int playerPoint = GetPlayerPoint(playerCards);
                Console.WriteLine("Ditt poäng: " + playerPoint);
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Dealers kort:");
                for (int i = 0; i < dealersCards.Count; i++)
                {
                    Console.WriteLine(dealersCards[i]._cardName + "|" + dealersCards[i]._cardType + "|" + dealersCards[i]._cardPoint);
                }
                int dealerPoint = GetDealerPoint(dealersCards);
                Console.WriteLine("Dealers poäng: " + dealerPoint);
                Console.WriteLine("-------------------------------------");
            }
        }
    }
}
