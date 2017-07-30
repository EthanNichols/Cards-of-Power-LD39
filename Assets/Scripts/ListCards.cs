using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListCards : MonoBehaviour {

    public GameObject cardInfo;
    public GameObject list;
    public GameObject button;

    private List<Card> cards = CardList.cards;

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
