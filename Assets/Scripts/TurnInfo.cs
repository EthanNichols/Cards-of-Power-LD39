using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnInfo : MonoBehaviour {

    //The max amount of time per round
    //The speed that the game runs at
    public float maxTurnTime;
    public float gameSpeed;

    //The current round of  the game
    //The amount of time left in the round
    private int currentRound;
    private float currentTime;

    //The text that displays the round timer
    //The text that displays the round number
    private Text timeDisplay;
    private Text roundDisplay;

	// Use this for initialization
	void Start () {
        //Set the current time to the max time
        //Set the round number
		currentTime = maxTurnTime;
        currentRound = 1;

        //Set the text location for the timer and the round number
        timeDisplay = transform.FindChild("Turn Timer").FindChild("Text").GetComponent<Text>();
        roundDisplay = transform.FindChild("Turn Number").FindChild("Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update () {

        //Decrease the amount of time left in the round
        currentTime -= Time.deltaTime * gameSpeed;

        //Display the amount of time left in the round
        //Display the round the game is on
        timeDisplay.text = Mathf.Ceil(currentTime).ToString();
        roundDisplay.text = "Round: " + currentRound;

        //Test if the timer has reach 0
        if (currentTime <= -.5)
        {
            //Reset the timer
            //Increase the round number
            currentTime = maxTurnTime;
            currentRound++;

            //Start the new round
            transform.parent.GetComponent<NextRound>().Begin();
        }
	}
}
