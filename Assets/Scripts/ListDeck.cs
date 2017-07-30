using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListDeck : MonoBehaviour
{

    public GameObject button;
    public GameObject cardInfo;
    public GameObject list;

    private List<Card> player1Deck;
    private List<Card> player2Deck;

    // Use this for initialization
    void Start()
    {
        player1Deck = Decks.player1Deck;
        player2Deck = Decks.player2Deck;
    }

    // Update is called once per frame
    void Update()
    {

        int amount = 0;

        if (button.transform.FindChild("Text").GetComponent<Text>().text.Contains("1"))
        {
            foreach (Card card in Decks.player1Deck)
            {
                amount += card.amountInDeck1;
            }
        }
        else
        {
            foreach (Card card in Decks.player2Deck)
            {
                amount += card.amountInDeck2;
            }
        }

        GetComponent<Text>().text = "Cards in Deck (" + amount + ")";

        AmountInDeck();
    }

    private void AmountInDeck()
    {
        List<Card> deck = null;

        foreach (Transform info in transform.FindChild("List frame").FindChild("List").FindChild("Grid").transform)
        {
            info.FindChild("Amount").GetComponent<Text>().text = "0 / " + info.gameObject.GetComponent<AllCardInfo>().card.amount;

            if (button.transform.FindChild("Text").GetComponent<Text>().text.Contains("1"))
            {
                foreach (Card deckCard in Decks.player1Deck)
                {
                    if (deckCard == info.gameObject.GetComponent<AllCardInfo>().card)
                    {
                        info.FindChild("Amount").GetComponent<Text>().text = deckCard.amountInDeck1 + " / " + info.gameObject.GetComponent<AllCardInfo>().card.amount;
                        break;
                    }
                }
            }
            else
            {
                foreach (Card deckCard in Decks.player2Deck)
                {
                    if (deckCard == info.gameObject.GetComponent<AllCardInfo>().card)
                    {
                        info.FindChild("Amount").GetComponent<Text>().text = deckCard.amountInDeck2 + " / " + info.gameObject.GetComponent<AllCardInfo>().card.amount;
                        break;
                    }
                }
            }
        }
    }

    public void ChangeList()
    {
        foreach (Transform child in list.transform)
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

        bool addCard = false;
        if (button.transform.FindChild("Text").GetComponent<Text>().text.Contains("1")) {
            if (card.amountInDeck1 < card.amount)
            {
                addCard = true;
            }
        }
        else
        {
            if (card.amountInDeck2 < card.amount)
            {
                addCard = true;
            }
        }
        if (addCard)
        {
            GameObject.Find("Cards / Decks").GetComponent<Decks>().AddToDeck(card, button.transform.FindChild("Text").GetComponent<Text>().text);
        }
    }

    public void remove(Card card)
    {
        GameObject.Find("Cards / Decks").GetComponent<Decks>().RemoveFromDeck(card, button.transform.FindChild("Text").GetComponent<Text>().text);
    }
}
