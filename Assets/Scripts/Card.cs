using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card {

    public string Name { get; set; }
    public int Cost { get; set; }
    public Sprite Image { get; set; }
    public string Description { get; set; }
    public int PowerAmount { get; set; }

    //What type of card power is being used
    public bool InstantGain { get; set; }
    public bool Steal { get; set; }
    public bool Remove { get; set; }

    public int UseCard()
    {
        if (InstantGain)
        {
            return PowerAmount;
        }

        return 0;
    }
}
