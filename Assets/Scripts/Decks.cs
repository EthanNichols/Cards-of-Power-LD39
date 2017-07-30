using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decks : MonoBehaviour {

    public static List<Card> player1Deck = new List<Card>();
    public static List<Card> player2Deck = new List<Card>();

    public static string Match;
    public static string winner = "";
    public static int turns;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (winner != "" &&
            GameObject.Find("Menus").GetComponent<ButtonClick>() != null)
        {
            GameObject.Find("Menus").GetComponent<ButtonClick>().WinScreen();
            winner = "";
            turns = 0;
        }
	}

    public void AddToDeck(Card card, string player)
    {
        if (player.Contains("1"))
        {
            if (player1Deck.Contains(card))
            {
                foreach (Card deckCard in player1Deck)
                {
                    if (card == deckCard)
                    {
                        deckCard.amountInDeck++;
                        break;
                    }
                }
            }
            else
            {
                player1Deck.Add(card);

                foreach (Card deckCard in player1Deck)
                {
                    if (card == deckCard)
                    {
                        deckCard.amountInDeck = 1;
                        break;
                    }
                }
            }

        } else
        {
            if (player2Deck.Contains(card))
            {
                foreach (Card deckCard in player2Deck)
                {
                    if (card == deckCard)
                    {
                        deckCard.amountInDeck++;
                        break;
                    }
                }
            }
            else
            {
                player2Deck.Add(card);

                foreach (Card deckCard in player2Deck)
                {
                    if (card == deckCard)
                    {
                        deckCard.amountInDeck = 1;
                        break;
                    }
                }
            }
        }

        GameObject.Find("Deck Cards").GetComponent<ListDeck>().ChangeList();
    }

    public void RemoveFromDeack(Card card, string player)
    {
        if (player.Contains("1"))
        {
            foreach (Card deckCard in player1Deck)
            {
                if (card == deckCard)
                {
                    deckCard.amountInDeck--;

                    if (deckCard.amountInDeck <= 0)
                    {
                        player1Deck.Remove(deckCard);
                    }
                    break;
                }
            }
        }
        else
        {
            foreach (Card deckCard in player2Deck)
            {
                if (card == deckCard)
                {
                    deckCard.amountInDeck--;

                    if (deckCard.amountInDeck <= 0)
                    {
                        player2Deck.Remove(deckCard);
                    }
                    break;
                }
            }
        }

        GameObject.Find("Deck Cards").GetComponent<ListDeck>().ChangeList();
    }
}
