using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsingCard : MonoBehaviour
{

    //The location where used cards are placed
    //The speed to remove visually destroy the card
    private GameObject usedPile;
    private float gameSpeed = 1;

    // Use this for initialization
    void Start()
    {
        //Set the used pil object
        usedPile = transform.parent.FindChild("Used Cards").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        bool createDeck = true;

        //Go through each child in the used pile
        foreach (Transform child in usedPile.transform)
        {
            //Calculate the shrinking speed of the card
            //Shrink the card
            float shrinkSpeed = Time.deltaTime * (gameSpeed / 2f);
            child.transform.localScale -= new Vector3(shrinkSpeed, shrinkSpeed, shrinkSpeed);

            //Test if the card isn't visbale anymore
            //Destroy the card
            if (child.transform.localScale.x <= 0)
            {
                Destroy(child.gameObject);
            }

            if (child.gameObject.activeInHierarchy)
            {
                createDeck = false;
            }
        }

        if (createDeck &&
            !transform.parent.gameObject.GetComponent<DeckInfo>())
        {
            Debug.Log("Allow deck");
            transform.parent.gameObject.AddComponent<DeckInfo>();
        }
    }

    public void PlaceInUsedPile(GameObject card)
    {
        //Instantiate the used card
        //Move the card to the  used pile position
        GameObject usedCard = Instantiate(card, Vector3.zero, Quaternion.identity);
        usedCard.transform.SetParent(usedPile.transform);
        usedCard.transform.localPosition = Vector3.zero;

        //Reset the scale of the card to 1
        //Remove the display script from the card so it won't move
        //Remove the button to view the card
        usedCard.transform.localScale = new Vector3(1, 1, 1);
        Destroy(usedCard.GetComponent<DisplayCard>());
        Destroy(usedCard.transform.FindChild("Button").gameObject);
    }

    public bool DrawnCard(Card card)
    {
        //Get all of the possible cards in you hand
        foreach (Transform child in transform)
        {
            //Test if there is a card in this spot in your hand
            if (!child.gameObject.activeInHierarchy)
            {
                //child.GetComponent<Image>().sprite;

                child.GetComponent<DisplayCard>().displayCard = card;

                //Set the information about the card in your hand relative to the card that you drew
                child.FindChild("Name").GetComponent<Text>().text = card.Name;
                child.FindChild("Cost").GetComponent<Text>().text = card.Cost.ToString();
                child.FindChild("Image").GetComponent<Image>().sprite = card.Image;
                child.FindChild("Description").GetComponent<Text>().text = card.Description;

                //Make the card visible in your hand
                child.gameObject.SetActive(true);

                return true;
            }
        }

        return false;
    }
}
