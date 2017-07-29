using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPower : MonoBehaviour {

    //The max, current, and production of power
    public float maxPower;
    public float currentPower;
    public int powerPerTurn;

    //The display for the amount of power the player has
    public GameObject powerBar;

    //Specific parts of the powerbar display
    private Slider slider;
    private Text text;
    private GameObject powerPerTurnDisplay;

    // Use this for initialization
    void Start () {

        //Set the specific parts of the power bar display
        slider = powerBar.GetComponent<Slider>();
        text = powerBar.transform.FindChild("Text").gameObject.GetComponent<Text>();
        powerPerTurnDisplay = powerBar.transform.FindChild("Power Per Turn").gameObject;
	}
	
	// Update is called once per frame
	void Update () {

        //Update the graphics of the power bar and production of power
        UpdatePowerBar();
        UpdatePerTurnPower();
	}

    private void UpdatePowerBar()
    {
        //Calculate the percentage that the power bar should be filled
        var percent = currentPower / maxPower;

        //If the percentage is over 1 then set it to 1
        if (percent >= 1)
        {
            percent = 1;
        }

        //If The player would have more power than the max set the current power to the max
        if (currentPower >= maxPower)
        {
            currentPower = maxPower;
        }

        //Set the fill amount for the power bar
        //Set the text display for the amount of power the player has
        slider.value = percent;
        text.text = currentPower + " / " + maxPower;
    }

    private void UpdatePerTurnPower()
    {
        //Find the text location for the power production per turn
        powerPerTurnDisplay.transform.FindChild("Text").GetComponent<Text>().text = "";

        //If the player isn't making any power per turn disable the display
        if (powerPerTurn == 0)
        {
            powerPerTurnDisplay.SetActive(false);
        } else
        {
            powerPerTurnDisplay.SetActive(true);
        }

        if (powerPerTurn < 0)
        {
            //If the player is not making power set the display to red
            powerPerTurnDisplay.GetComponent<Image>().color = new Color(.8f, .2f, .3f);
        } else if (powerPerTurn > 0)
        {
            //If the player is making power set the display to green
            //Place a '+' in front of the production amount
            powerPerTurnDisplay.GetComponent<Image>().color = new Color(.2f, .8f, .3f);
            powerPerTurnDisplay.transform.FindChild("Text").GetComponent<Text>().text = "+";
        }

        //Add the amount of production to the display
        powerPerTurnDisplay.transform.FindChild("Text").GetComponent<Text>().text += powerPerTurn.ToString();
    }

    public void PowerForTurn()
    {
        //Increase the amount of power based on the production per turn
        currentPower += powerPerTurn;
    }
}
