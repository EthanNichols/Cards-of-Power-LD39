using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
