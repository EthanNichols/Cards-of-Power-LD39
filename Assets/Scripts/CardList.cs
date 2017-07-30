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
        cards.Add(new Card() { Name = "Instant Power", index = 0, Cost = 0, Image = null, Description = "Instantly add 15 power" });
        cards.Add(new Card() { Name = "Steal Power", index = 1, Cost = 2, Image = null, Description = "You gain 7 power, while your opponent loses 8 power" });
        cards.Add(new Card() { Name = "Remove Power", index = 2, Cost = 3, Image = null, Description = "Remove 10 power from your opponent" });
        cards.Add(new Card() { Name = "Apartment", index = 3, Cost = 3, Image = null, Health = 5, Attack = 2, Defense=4, EnergyConsumption=1, AbsorbAttack=true, Description = "A small space for someone to live" });

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
