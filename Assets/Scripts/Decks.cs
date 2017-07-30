using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decks : MonoBehaviour {

    public static List<Card> player1Deck = new List<Card>();
    public static List<Card> player2Deck = new List<Card>();

    public static string Match;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddToDeck(Card card, string player)
    {
        if (player.Contains("1"))
        {
            player1Deck.Add(card);
        } else
        {
            player2Deck.Add(card);
        }

        GameObject.Find("Deck Cards").GetComponent<ListDeck>().ChangeList();
    }

    public void RemoveFromDeack(Card card, string player)
    {
        if (player.Contains("1"))
        {
            player1Deck.Remove(card);
        }
        else
        {
            player2Deck.Remove(card);
        }

        GameObject.Find("Deck Cards").GetComponent<ListDeck>().ChangeList();
    }
}
