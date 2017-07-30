using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHover : MonoBehaviour {

    private bool hovering = false;

	// Use this for initialization
	void Start () {	
	}
	
	// Update is called once per frame
	void Update () {
		if (hovering)
        {
            GetComponent<Image>().color = new Color(.2f, .8f, .3f);
        } else
        {
            GetComponent<Image>().color = new Color(.85f, .9f, .3f);
        }
	}

    public void Enter()
    {
        hovering = true;
    }

    public void Exit()
    {
        hovering = false;
    }
}
