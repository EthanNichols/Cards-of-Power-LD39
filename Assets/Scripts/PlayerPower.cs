using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPower : MonoBehaviour {

    public float maxPower;
    public float currentPower;
    public int powerPerTurn = 20;

    public GameObject powerBar;

    private Slider slider;
    private Text text;
    private GameObject powerPerTurnDisplay;

    // Use this for initialization
    void Start () {
        slider = powerBar.GetComponent<Slider>();
        text = powerBar.transform.FindChild("Text").gameObject.GetComponent<Text>();
        powerPerTurnDisplay = powerBar.transform.FindChild("Power Per Turn").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        UpdatePowerBar();
        UpdatePerTurnPower();
	}

    private void UpdatePowerBar()
    {
        var percent = currentPower / maxPower;

        if (percent >= 1)
        {
            percent = 1;
        }

        if (currentPower >= maxPower)
        {
            currentPower = maxPower;
        }

        slider.value = percent;
        text.text = currentPower + " / " + maxPower;
    }

    private void UpdatePerTurnPower()
    {
        powerPerTurnDisplay.transform.FindChild("Text").GetComponent<Text>().text = "";

        if (powerPerTurn == 0)
        {
            powerPerTurnDisplay.SetActive(false);
        } else
        {
            powerPerTurnDisplay.SetActive(true);
        }

        if (powerPerTurn < 0)
        {
            powerPerTurnDisplay.GetComponent<Image>().color = new Color(.8f, .2f, .3f);
        } else if (powerPerTurn > 0)
        {
            powerPerTurnDisplay.GetComponent<Image>().color = new Color(.2f, .8f, .3f);
            powerPerTurnDisplay.transform.FindChild("Text").GetComponent<Text>().text = "+";
        }

        powerPerTurnDisplay.transform.FindChild("Text").GetComponent<Text>().text += powerPerTurn.ToString();
    }

    public void PowerForTurn()
    {
        currentPower += powerPerTurn;
    }
}
