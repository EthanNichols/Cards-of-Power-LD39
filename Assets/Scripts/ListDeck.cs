using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListDeck : MonoBehaviour {

    public GameObject button;
    public GameObject cardInfo;
    public GameObject list;

    private List<Card> player1Deck;
    private List<Card> player2Deck;

	// Use this for initialization
	void Start () {
        player1Deck = Decks.player1Deck;
        player2Deck = Decks.player2Deck;
	}
	
	// Update is called once per frame
	void Update () {

        List<Card> deck = null;

        if (button.transform.FindChild("Text").GetComponent<Text>().text.Contains("1"))
        {
            deck = player1Deck;
        }
        else
        {
            deck = player2Deck;
        }

        GetComponent<Text>().text = "List of Cards (" + deck.Count + ")";
	}

    public void ChangeList()
    {
        foreach(Transform child in list.transform)
        {
            Destroy(child.gameObject);
        }

        List<Card> deck = null;

        if (button.transform.FindChild("Text").GetComponent<Text>().text.Contains("1"))
        {
            deck = player1Deck;
        }
        else
        {
            deck = player2Deck;
        }

        foreach (Card card in deck)
        {
            var displayInfo = Instantiate(cardInfo, Vector3.zero, Quaternion.identity);

            displayInfo.transform.SetParent(list.transform);
            displayInfo.GetComponent<AllCardInfo>().card = card;

            displayInfo.transform.FindChild("Name").GetComponent<Text>().text = card.Name;
            displayInfo.transform.FindChild("Description").GetComponent<Text>().text = card.Description;
            displayInfo.transform.FindChild("Image").GetComponent<Image>().sprite = card.Image;
            displayInfo.transform.FindChild("Cost").GetComponent<Text>().text = card.Cost.ToString();
        }
    }

    public void Add(Card card)
    {
        GameObject.Find("Cards / Decks").GetComponent<Decks>().AddToDeck(card, button.transform.FindChild("Text").GetComponent<Text>().text);
    }

    public void remove(Card card)
    {
        GameObject.Find("Cards / Decks").GetComponent<Decks>().RemoveFromDeack(card, button.transform.FindChild("Text").GetComponent<Text>().text);
    }
}
