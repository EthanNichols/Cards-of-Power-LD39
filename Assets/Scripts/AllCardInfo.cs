using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllCardInfo : MonoBehaviour {

    public Card card;

    public void add()
    {
        GameObject.Find("Card List").GetComponent<ListCards>().Add(card);
    }

    public void remove()
    {
        GameObject.Find("Card List").GetComponent<ListCards>().remove(card);
    }
}
