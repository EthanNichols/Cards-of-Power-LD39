using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPower : MonoBehaviour {

    public float maxPower;
    public float currentPower;

    public GameObject powerBar;

    private Slider slider;
    private Text text;

	// Use this for initialization
	void Start () {
        slider = powerBar.GetComponent<Slider>();
        text = powerBar.transform.FindChild("Text").gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {

        var percent = currentPower / maxPower;
        
        if(percent >= 1)
        {
            percent = 1;
        }

        slider.value = percent;
        text.text = currentPower + " / " + maxPower;
	}
}
