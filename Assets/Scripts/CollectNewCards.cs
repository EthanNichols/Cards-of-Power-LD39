using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectNewCards : MonoBehaviour {

    public GameObject newCards;

	// Use this for initialization
	void Start () {
        CollectCards();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CollectCards()
    {
        var cards = Instantiate(newCards, Vector3.zero, Quaternion.identity);

        cards.transform.SetParent(transform);
        cards.transform.localPosition = Vector3.zero;

        float pos = -2.5f;

        foreach(Transform child in cards.transform)
        {
            Destroy(child.GetComponent<DisplayCard>());
            Destroy(child.FindChild("Button").gameObject);
            child.localPosition = Vector3.zero;
            child.gameObject.SetActive(true);
            child.localPosition = new Vector3(pos * (child.GetComponent<RectTransform>().rect.width * 1.5f), -100, 0);

            var newCard = CardList.CollectCard();

            child.FindChild("Name").GetComponent<Text>().text = newCard.Name;
            child.FindChild("Cost").GetComponent<Text>().text = newCard.Cost.ToString();
            child.FindChild("Description").GetComponent<Text>().text = newCard.Description;
            child.FindChild("Image").GetComponent<Image>().sprite = newCard.Image;

            pos++;
        }

        Debug.Log("New Cards");
    }

    public void DeleteCards()
    {
        if (transform.FindChild("Cards"))
        {
            Destroy(transform.FindChild("Cards"));
        }
    }
}
