using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour {

    GameObject startingScreen;
    GameObject mainMenu;
    GameObject setupGame;
    GameObject credits;
    GameObject editDeck;

    GameObject currentMenu;
    GameObject lastMenu;

    void Start()
    {
        startingScreen = transform.FindChild("Starting Cards").gameObject;
        mainMenu = transform.FindChild("Main Menu").gameObject;
        setupGame = transform.FindChild("Game Setup").gameObject;
        credits = transform.FindChild("Credits").gameObject;
        editDeck = transform.FindChild("Edit Decks").gameObject;

        currentMenu = startingScreen;
        lastMenu = startingScreen;
    }

    public void StartingCards(string amount)
    {
        if (amount == "all")
        {

        } else
        {

        }

        startingScreen.SetActive(false);
        mainMenu.SetActive(true);
        lastMenu = startingScreen;
        currentMenu = mainMenu;
    }

    public void SetupMatch()
    {
        lastMenu = currentMenu;
        currentMenu = setupGame;
        lastMenu.SetActive(false);
        currentMenu.SetActive(true);
    }

    public void StartMatch(string type)
    {
        if (type == "computer")
        {

        } else if (type == "2 player")
        {

        }

        SceneManager.LoadScene("Game");
    }

    public void EditDecks()
    {
        lastMenu = currentMenu;
        currentMenu = editDeck;
        lastMenu.SetActive(false);
        currentMenu.SetActive(true);
    }

    public void Credits()
    {
        credits.SetActive(true);
        mainMenu.SetActive(false);
        currentMenu = credits;
        lastMenu = mainMenu;
    }

    public void Return()
    {
        lastMenu.SetActive(true);
        currentMenu.SetActive(false);
    }

    public void ChangePlayer(GameObject button)
    {
        if (button.transform.FindChild("Text").GetComponent<Text>().text == "Player 1 Deck")
        {
            button.transform.FindChild("Text").GetComponent<Text>().text = "Player 2 Deck";
        } else
        {
            button.transform.FindChild("Text").GetComponent<Text>().text = "Player 1 Deck";
        }

        GameObject.Find("Deck Cards").GetComponent<ListDeck>().ChangeList();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
