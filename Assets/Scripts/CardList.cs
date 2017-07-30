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
        cards.Add(new Card() { Name = "Instant Power", cardType = "instant", Cost = 0, cardPower=15, Image = null, Description = "Instantly add 15 power" });
        cards.Add(new Card() { Name = "Steal Power", cardType = "steal", Cost = 2, cardPower=15, Image = null, Description = "You gain 7 power, while your opponent loses 8 power" });
        cards.Add(new Card() { Name = "Remove Power", cardType = "remove", cardPower=10, Cost = 3, Image = null, Description = "Remove 10 power from your opponent" });
        cards.Add(new Card() { Name = "Apartment", cardType = "building", Cost = 3, Image = null, Health = 5, Attack = 2, Defense=4, EnergyConsumption=1, AttackBuilding=true, Description = "A small space for someone to live. Consumes 1 Energy per turn" });
        cards.Add(new Card() { Name = "Coal Burner", cardType = "building", Cost = 3, Image = null, Health = 10, Attack = 2, Defense = 4, EnergyConsumption = -2, AttackBuilding = true, Description = "Create 2 energy per turn" });
        cards.Add(new Card() { Name = "Destroy Building", cardType = "destroy", Cost = 3, Image = null, Description = "Randomly destroy one of your opponents buildings" });
        cards.Add(new Card() { Name = "Draw Energy", cardType = "draw", Cost = 3, cardPower = 2, Image = null, Description = "Draw 2 cards from your deck" });

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
