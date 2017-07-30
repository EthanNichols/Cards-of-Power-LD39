using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card {

    public string Name { get; set; }
    public string cardType { get; set; }
    public int Cost { get; set; }
    public Sprite Image { get; set; }
    public string Description { get; set; }
    public int cardPower { get; set; }

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

        switch(cardType)
        {
            case "instant":
                userPower.currentPower += cardPower;
                break;
            case "steal":
                userPower.currentPower += cardPower-1;
                otherPower.currentPower -= cardPower;
                break;
            case "remove":
                otherPower.currentPower -= cardPower;
                break;
            case "building":
                bool built = user.transform.FindChild("City").GetComponent<Buildings>().BuildBuilding(this);
                if (built)
                {
                    userPower.powerPerTurn -= this.EnergyConsumption;
                }
                break;
            case "destroy":
                otherPlayer.transform.FindChild("City").GetComponent<Buildings>().DestroyBuilding(otherPlayer);
                break;
            case "draw":
                for (int i = 0; i < cardPower; i++)
                {
                    user.GetComponent<DeckInfo>().DrawCard();
                }
                break;
        }
    }
}
