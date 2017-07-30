using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextRound : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Begin()
    {
        //Find both players
        var player1 = transform.FindChild("Player 1");
        var player2 = transform.FindChild("Player 2");

        //Make both players gain/lose the power for the turn
        player1.GetComponent<PlayerPower>().PowerForTurn();
        player2.GetComponent<PlayerPower>().PowerForTurn();

        player1.FindChild("City").GetComponent<Buildings>().BuildingAttack(player1.gameObject);
        player2.FindChild("City").GetComponent<Buildings>().BuildingAttack(player2.gameObject);

        //Make both players draw a card
        player1.GetComponent<DeckInfo>().DrawCard();
        player2.GetComponent<DeckInfo>().DrawCard();
    }
}
