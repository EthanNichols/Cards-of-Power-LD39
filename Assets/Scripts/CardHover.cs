using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHover : MonoBehaviour {

    private List<GameObject> cards = new List<GameObject>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.childCount != cards.Count)
        {
            cards.Clear();

            foreach(Transform child in transform)
            {
                cards.Add(child.gameObject);
            }
        }
	}
}
