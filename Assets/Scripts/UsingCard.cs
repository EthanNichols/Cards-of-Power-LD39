using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsingCard : MonoBehaviour
{

    private GameObject usedPile;
    private float gameSpeed = 1;

    // Use this for initialization
    void Start()
    {
        usedPile = transform.parent.FindChild("Used Cards").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Transform child in usedPile.transform)
        {
            float shrinkSpeed = Time.deltaTime * (gameSpeed / 2f);
            child.transform.localScale -= new Vector3(shrinkSpeed, shrinkSpeed, shrinkSpeed);

            if (child.transform.localScale.x <= 0)
            {
                Destroy(child.gameObject);
            }
        }
    }

    public void PlaceInUsedPile(GameObject card)
    {
        GameObject usedCard = Instantiate(card, Vector3.zero, Quaternion.identity);
        usedCard.transform.SetParent(usedPile.transform);
        usedCard.transform.localPosition = Vector3.zero;
        usedCard.transform.localScale = new Vector3(1, 1, 1);
        Destroy(usedCard.GetComponent<DisplayCard>());
        Destroy(usedCard.transform.FindChild("Button").gameObject);
    }

    public bool DrawnCard(Card card)
    {
        foreach (Transform child in transform)
        {

            if (!child.gameObject.activeInHierarchy)
            {
                //child.GetComponent<Image>().sprite;

                child.FindChild("Name").GetComponent<Text>().text = card.Name;
                child.FindChild("Cost").GetComponent<Text>().text = card.Cost.ToString();
                child.FindChild("Image").GetComponent<Image>().sprite = card.Image;
                child.FindChild("Description").GetComponent<Text>().text = card.Description;

                child.gameObject.SetActive(true);

                return true;
            }
        }

        return false;
    }
}
