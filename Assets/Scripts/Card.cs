using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card {

    public string Name { get; set; }
    public int index { get; set; }
    public int Cost { get; set; }
    public Sprite Image { get; set; }
    public string Description { get; set; }

    public int Health { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public bool AttackBuilding { get; set; }
    public bool AbsorbAttack { get; set; }

    public Sprite BuildingImage { get; set; }
    public int EnergyConsumption { get; set; }

    public void useCard(GameObject user, GameObject otherPlayer)
    {
        var userPower = user.GetComponent<PlayerPower>();
        var otherPower = otherPlayer.GetComponent<PlayerPower>();

        if (userPower.currentPower < Cost)
        {
            return;
        } else
        {
            userPower.currentPower -= Cost;
        }

        switch(index)
        {
            case 0:
                userPower.currentPower += 15;
                break;
            case 1:
                userPower.currentPower += 7;
                otherPower.currentPower -= 8;
                break;
            case 2:
                otherPower.currentPower -= 10;
                break;
            default:
                user.transform.FindChild("City").GetComponent<Buildings>().BuildBuilding(this);
                break;
        }
    }
}
