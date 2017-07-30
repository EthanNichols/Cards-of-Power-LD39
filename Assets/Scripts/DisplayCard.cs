using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCard : MonoBehaviour
{

    //The button to view the card
    //The button to use the viewed card
    public KeyCode button;
    public KeyCode useCard;

    public Card displayCard;

    //The location of the card in the hand
    //Whether the card is being looked at or not
    //The speed for the card movement
    private int siblingPosition;
    private bool display = false;
    private float speed = 2000;

    // Use this for initialization
    void Start()
    {
        //Set the location of the card in your hand
        //Set the position of the card in the hand
        siblingPosition = transform.GetSiblingIndex();
        transform.localPosition += new Vector3(siblingPosition * 125, 0, 0);

        //Set which button should be pressed to view the card
        transform.FindChild("Button").GetComponent<Text>().text = (siblingPosition + 1).ToString();

        if (button.ToString().Contains("Alpha"))
        {
            var buttonName = button.ToString().Substring(button.ToString().Length - 1);
            transform.FindChild("Button").GetComponent<Text>().text = buttonName;

        } else if (button.ToString().Contains("Bracket")) {
            if (button.ToString().Contains("Left"))
            {
                transform.FindChild("Button").GetComponent<Text>().text = "{";
            }
            else if (button.ToString().Contains("Right"))
            {
                transform.FindChild("Button").GetComponent<Text>().text = "}";
            }
        } else
        {
            transform.FindChild("Button").GetComponent<Text>().text = button.ToString();
        }

        //Make the cards invisible at the start of the game
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Test if the player is viewing a card
        if (Input.GetKey(button))
        {
            Display();

        //Test when the player stops viewing the card
        } else if (Input.GetKeyUp(button))
        {
            Undisplay();
        }

        //Move/Use the card
        MoveCard();
        UseCard();
    }

    private void MoveCard()
    {
        //If the card is being viewed move the card so the description is visible
        //If the card isn't being viewed move the card back into the hand
        if (display)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(transform.localPosition.x, -475, 0), speed * Time.deltaTime);
        }
        else
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(transform.localPosition.x, -600, 0), speed * Time.deltaTime);
        }
    }

    private void UseCard()
    {
        //Test for the card to be used
        //Make sure the card is also being viewed
        if ((Input.GetKey(useCard) ||
            Input.GetMouseButtonDown(0)) &&
            display)
        {
            GameObject user = transform.parent.parent.gameObject;
            GameObject otherUser = null;
            int otherNum = 1;

            if (user.name.Contains("1"))
            {
                otherNum = 2;
            }

            otherUser = transform.parent.parent.parent.FindChild("Player " + otherNum).gameObject;

            displayCard.useCard(user, otherUser);

            //Move the card back into the player's hand
            transform.localPosition = new Vector3(transform.localPosition.x, -600, 0);
            Undisplay();

            //Create the card in the used card pile
            //Remove the card from the player's hand
            transform.parent.GetComponent<UsingCard>().PlaceInUsedPile(gameObject);
            gameObject.SetActive(false);
        }
    }

    public void Display()
    {
        //Move the card to the front of the others
        transform.SetAsLastSibling();
        display = true;
    }

    public void Undisplay()
    {
        //Move the card back to it's original location in the hand
        transform.SetSiblingIndex(siblingPosition);
        display = false;
    }
}
