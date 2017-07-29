using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnInfo : MonoBehaviour {

    public float maxTurnTime;
    public float gameSpeed;

    private int currentRound;
    private float currentTime;
    private Text timeDisplay;
    private Text roundDisplay;

	// Use this for initialization
	void Start () {
		currentTime = maxTurnTime;

        timeDisplay = transform.FindChild("Turn Timer").FindChild("Text").GetComponent<Text>();
        roundDisplay = transform.FindChild("Turn Number").FindChild("Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update () {
        currentTime -= Time.deltaTime * gameSpeed;

        timeDisplay.text = Mathf.Ceil(currentTime).ToString();
        roundDisplay.text = "Round: " + currentRound;

        if (currentTime <= -.5)
        {
            currentTime = maxTurnTime;
            currentRound++;
        }
	}
}
