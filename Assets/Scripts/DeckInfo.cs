using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckInfo : MonoBehaviour {

    Stack<Card> deck = new Stack<Card>();

	// Use this for initialization
	void Start () {

        for (int i=0; i<50; i++)
        {
            deck.Push(CardList.cards[Random.Range(0, CardList.cards.Count)]);
        }

        for (int i=0; i<3; i++)
        {
            transform.FindChild("Cards").GetComponent<UsingCard>().DrawnCard(deck.Peek());
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DrawCard()
    {
        if (transform.FindChild("Cards").GetComponent<UsingCard>().DrawnCard(deck.Peek()))
        {
            deck.Pop();
        } else
        {
            GetComponent<PlayerPower>().powerPerTurn--;
        }
    }
}
