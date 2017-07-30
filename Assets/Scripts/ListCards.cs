using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListCards : MonoBehaviour {

    public GameObject cardInfo;
    public GameObject list;
    public GameObject button;

    private List<Card> cards = CardList.cards;
    private List<GameObject> allInfo = new List<GameObject>();

	// Use this for initialization
	void Start () {


		foreach(Card card in cards)
        {
            var displayInfo = Instantiate(cardInfo, Vector3.zero, Quaternion.identity);

            displayInfo.transform.SetParent(list.transform);
            displayInfo.GetComponent<AllCardInfo>().card = card;

            displayInfo.transform.FindChild("Name").GetComponent<Text>().text = card.Name;
            displayInfo.transform.FindChild("Description").GetComponent<Text>().text = card.Description;
            displayInfo.transform.FindChild("Image").GetComponent<Image>().sprite = card.Image;
            displayInfo.transform.FindChild("Cost").GetComponent<Text>().text = card.Cost.ToString();

            allInfo.Add(displayInfo);
        }
	}

    void Update()
    {
        List<Card> deck = null;

        if (button.transform.FindChild("Text").GetComponent<Text>().text.Contains("1"))
        {
            deck = Decks.player1Deck;
        } else
        {
            deck = Decks.player2Deck;
        }

        foreach(GameObject info in allInfo)
        {
            info.transform.FindChild("Amount").GetComponent<Text>().text = "0 / " + info.GetComponent<AllCardInfo>().card.amount;

            foreach (Card deckCard in deck)
            {
                if (deckCard == info.GetComponent<AllCardInfo>().card)
                {
                    info.transform.FindChild("Amount").GetComponent<Text>().text = deckCard.amountInDeck + " / " + info.GetComponent<AllCardInfo>().card.amount;
                    break;
                }
            }
        }
    }

    public void Add(Card card)
    {
        if (card.amountInDeck < card.amount)
        {
            GameObject.Find("Cards / Decks").GetComponent<Decks>().AddToDeck(card, button.transform.FindChild("Text").GetComponent<Text>().text);
        }
    }

    public void remove(Card card)
    {
        GameObject.Find("Cards / Decks").GetComponent<Decks>().RemoveFromDeack(card, button.transform.FindChild("Text").GetComponent<Text>().text);
    }
}
