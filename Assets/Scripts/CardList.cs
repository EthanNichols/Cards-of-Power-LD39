using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardList : MonoBehaviour
{
    public List<Sprite> cardImages = new List<Sprite>();
    public List<Sprite> buildingImages = new List<Sprite>();

    //The list of cards that can be used
    public static List<Card> cards = new List<Card>();

    public static bool collectCards;

    // Use this for initialization
    void Awake()
    {
        //Create cards
        cards.Add(new Card() { Name = "Small Battery", cardType = "instant", Cost = 0, cardPower = 5, Image = cardImages[0], Description = "A small battery, that instantly gives you 5 Energy" });
        cards.Add(new Card() { Name = "Medium Battery", cardType = "instant", Cost = 5, cardPower = 15, Image = cardImages[1], Description = "A medium battery, that instantly gives you 15 Energy" });
        cards.Add(new Card() { Name = "Large Power", cardType = "instant", Cost = 8, cardPower = 25, Image = cardImages[2], Description = "A large battery, that instantly gives you 25 Energy" });

        cards.Add(new Card() { Name = "Steal Power", cardType = "steal", Cost = 2, cardPower = 15, Image = cardImages[3], Description = "You steal 7 Energy, while your opponent loses 8 Energy" });
        cards.Add(new Card() { Name = "Control Power", cardType = "steal", Cost = 5, cardPower = 17, Image = cardImages[4], Description = "You steal 17 Energy, while your opponent loses 18 Energy" });

        cards.Add(new Card() { Name = "Destroy Power", cardType = "remove", cardPower = 10, Cost = 3, Image = cardImages[5], Description = "Instantly destroy 10 Energy from your opponent" });

        cards.Add(new Card() { Name = "Land Waste", cardType = "building", Cost = 2, Image = cardImages[6], BuildingImage = buildingImages[0], Health = 10, Attack = 0, Defense = 2, AbsorbAttack = true, EnergyConsumption = 0, Description = "10 HP, 1 Defense, Defender. Doesn't consume any Energy per turn" });
        cards.Add(new Card() { Name = "Apartment", cardType = "building", Cost = 4, Image = cardImages[7], BuildingImage = buildingImages[1], Health = 1, Attack = 2, Defense = 0, EnergyConsumption = 1, Description = "1 Health, 1 Attack. Consumes 1 Energy per turn" });
        cards.Add(new Card() { Name = "House", cardType = "building", Cost = 7, Image = cardImages[8], BuildingImage = buildingImages[2], Health = 3, Attack = 4, Defense = 1, EnergyConsumption = 2, Description = "3 Health, 4 Attack, 1 Defense. Consumes 2 Energy Per turn" });
        cards.Add(new Card() { Name = "Sky Scraper", cardType = "building", Cost = 9, Image = cardImages[9], BuildingImage = buildingImages[3], Health = 2, Attack = 7, Defense = 0, AttackBuilding=true, EnergyConsumption = 4, Description = "2 Health, 7 Attack, Attacker. Consumes 4 Energy Per turn" });

        cards.Add(new Card() { Name = "Solar Panels", cardType = "building", Cost = 2, Image = cardImages[24], BuildingImage = buildingImages[4], Health = 1, EnergyConsumption = -1, Description = "Generates 1 Energy Per Turn" });
        cards.Add(new Card() { Name = "Wind Turbines", cardType = "building", Cost = 5, Image = cardImages[25], BuildingImage = buildingImages[5], Health = 1, Defense=1, EnergyConsumption = -2, Description = "Generates 2 Energy Per Turn" });
        cards.Add(new Card() { Name = "Coal Generator", cardType = "building", Cost = 7, Image = cardImages[26], BuildingImage = buildingImages[6], Health = 3, Defense=2, EnergyConsumption = -3, Description = "Generates 3 Energy Per Turn" });

        cards.Add(new Card() { Name = "Destroy Building", cardType = "destroy", Cost = 4, Image = cardImages[10], Description = "Randomly destroy one of your opponents buildings" });

        cards.Add(new Card() { Name = "Draw Energy", cardType = "draw", Cost = 3, cardPower = 2, Image = cardImages[11], Description = "Draw 2 cards from your deck" });
        cards.Add(new Card() { Name = "Draw More Energy", cardType = "draw", Cost = 4, cardPower = 3, Image = cardImages[12], Description = "Draw 3 cards from your deck" });

        cards.Add(new Card() { Name = "Add Turrets", cardType = "buff", Cost = 3, cardPower = 2, Attack = 2, Image = cardImages[13], Description = "One of your buildings gains 2 attack" });
        cards.Add(new Card() { Name = "Increase Range", cardType = "buff", Cost = 3, cardPower = 3, Attack = 2, Image = cardImages[14], Description = "One of your buildings gains 3 attack" });

        cards.Add(new Card() { Name = "Reinforce", cardType = "buff", Cost = 2, cardPower = 6, Health = 4, Image = cardImages[15], Description = "One of your buildings gains 4 health" });

        cards.Add(new Card() { Name = "Build a Wall", cardType = "buff", Cost = 1, cardPower = 7, Defense = 2, Image = cardImages[16], Description = "One of your buildings gains 2 defense" });
        cards.Add(new Card() { Name = "Add metal", cardType = "buff", Cost = 3, cardPower = 7, Defense = 7, Image = cardImages[17], Description = "One of your buildings gains 7 defense" });

        cards.Add(new Card() { Name = "Overall Upgrade", cardType = "buff", Cost = 5, cardPower = 7, Defense = 3, Attack = 3, Health = 3, Image = cardImages[18], Description = "One of your buildings gains 3 health, 3 attack, and 3 defense" });

        cards.Add(new Card() { Name = "More Energy", cardType = "perTurn", Cost = 5, cardPower = 3, Image = cardImages[19], Description = "Gain 3 Energy per turn" });
        cards.Add(new Card() { Name = "Much More Energy", cardType = "perTurn", Cost = 7, cardPower = 3, Image = cardImages[20], Description = "Gain 5 Energy per turn" });

        cards.Add(new Card() { Name = "Attack Buildings", cardType = "buff", Cost = 3, cardPower = 2, AttackBuilding = true, Image = cardImages[21], Description = "One of your buildings will start attacking buildings instead of the player directly" });
        cards.Add(new Card() { Name = "Absorb Damage", cardType = "buff", Cost = 3, cardPower = 2, AbsorbAttack = true, Image = cardImages[22], Description = "One of your buildings will start absorbing attacks for you" });
        cards.Add(new Card() { Name = "Normalize", cardType = "buff", Cost = 3, cardPower = 2, AttackBuilding = false, AbsorbAttack=false, Image = cardImages[23], Description = "One of your buildings will directly attack your opponents Energy" });

        DontDestroyOnLoad(gameObject);
    }

    public static void gameChoice()
    {
        if (collectCards)
        {
            randomCards(30);
            foreach (Card card in cards)
            {
                card.amountInDeck1 = 0;
                card.amountInDeck2 = 0;
            }
        }
        else
        {
            foreach (Card card in cards)
            {
                card.amount = 7;
                card.amountInDeck1 = 0;
                card.amountInDeck2 = 0;
            }
        }
    }

    public static void randomCards(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            cards[Random.Range(0, cards.Count)].amount++;
        }

        foreach (Card card in cards)
        {
            if (card.amount >= 7)
            {
                card.amount = 7;
            }
        }
    }

    public static Card CollectCard()
    {
        Card newCard = cards[Random.Range(0, cards.Count)];
        newCard.amount++;

        foreach (Card card in cards)
        {
            if (card.amount >= 7)
            {
                card.amount = 7;
            }
        }

        return newCard;
    }
}
