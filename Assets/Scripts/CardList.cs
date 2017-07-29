using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardList : MonoBehaviour {

    //The game
    //The list of cards that can be used
    public GameObject game;
    public static List<Card> cards = new List<Card>();

	// Use this for initialization
	void Awake () {
        //Create cards
        cards.Add(new Card() { Name = "Instant Power", Cost = 0, Image = null, Description = "Instantly add 15 power" });
        cards.Add(new Card() { Name = "Steal Power", Cost = 2, Image = null, Description = "Steal 8 Power from your opponent" });
        cards.Add(new Card() { Name = "Remove Power", Cost = 3, Image = null, Description = "Remove 10 power from your opponent" });

        //Start the game
        StartGame();
    }

    // Update is called once per frame
    void Update () {
	}

    private void StartGame()
    {
        //Enable the game canvas
        game.SetActive(true);
    }
}
