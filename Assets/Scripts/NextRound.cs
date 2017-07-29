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
        DrawCard();
    }

    private void DrawCard()
    {
        var player1 = transform.FindChild("Player 1");
        var player2 = transform.FindChild("Player 2");

        player1.GetComponent<PlayerPower>().PowerForTurn();
        player2.GetComponent<PlayerPower>().PowerForTurn();

        player1.GetComponent<DeckInfo>().DrawCard();
        player2.GetComponent<DeckInfo>().DrawCard();
    }
}
