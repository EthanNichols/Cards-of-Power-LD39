using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Buildings : MonoBehaviour
{
    public Sprite grass;
    public Dictionary<GameObject, Building> tiles = new Dictionary<GameObject, Building>();

    public GameObject hitMarker;

    // Use this for initialization
    void Start()
    {
    }

    public void GetTiles()
    {
        foreach (Transform child in transform)
        {
            if (!child.name.Contains("Hit"))
            {
                tiles.Add(child.gameObject, null);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (KeyValuePair<GameObject, Building> tile in tiles)
        {
            if (tile.Key.transform.childCount > 0)
            {
                foreach(Transform child in tile.Key.transform)
                {
                    if (child.name.Contains("Hit"))
                    {
                        child.localScale -= new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime) * .7f;

                        if (child.localScale.x <= 0)
                        {
                            Destroy(child.gameObject);
                        }
                    }
                }
            }

            if (tile.Value != null)
            {
                Debug.Log(tile.Key);

                if (tile.Value.Health <= 0)
                {
                    transform.parent.GetComponent<PlayerPower>().powerPerTurn += tiles[tile.Key].EnergyConsumption;
                    tiles[tile.Key] = null;
                }

                tile.Key.GetComponent<Image>().sprite = tile.Value.Image;

                tile.Key.transform.FindChild("Health").GetComponent<Text>().text = "HP: " + tile.Value.Health + " ";

                var attack = tile.Value.Attack;
                var defense = tile.Value.Defense;
                tile.Key.transform.FindChild("Stats").GetComponent<Text>().text = attack + " / " + defense + " ";
            } else
            {
                tile.Key.GetComponent<Image>().sprite = grass;
                tile.Key.transform.FindChild("Health").GetComponent<Text>().text = "";
                tile.Key.transform.FindChild("Stats").GetComponent<Text>().text = "";
            }
        }
    }

    public void BuildingAttack(GameObject player)
    {
        GameObject player1 = GameObject.Find("Player 1");
        GameObject player2 = GameObject.Find("Player 2");

        GameObject attackingPlayer = player;
        GameObject defendingPlayer = null;

        if (attackingPlayer == player1)
        {
            attackingPlayer = player1;
            defendingPlayer = player2;
        }
        else
        {
            attackingPlayer = player2;
            defendingPlayer = player1;
        }

        var totalAmount = 0;

        foreach (KeyValuePair<GameObject, Building> tile1 in attackingPlayer.transform.FindChild("City").GetComponent<Buildings>().tiles)
        {
            var dealtDamage = false;

            foreach (KeyValuePair<GameObject, Building> tile2 in defendingPlayer.transform.FindChild("City").GetComponent<Buildings>().tiles)
            {
                if (tile1.Value != null &&
                    tile2.Value != null)
                {
                    if (tile1.Value.AttackBuilding ||
                        tile2.Value.AbsorbAttack)
                    {
                        var attack = CalcDamage(tile1.Value.Attack, tile2.Value.Defense);
                        dealtDamage = true;

                        var hit = Instantiate(hitMarker, Vector3.zero, Quaternion.identity);
                        hit.transform.SetParent(tile2.Key.transform);
                        hit.transform.localPosition = Vector3.zero;
                        hit.transform.localScale = new Vector3(.4f, .4f, .4f);
                        hit.transform.FindChild("Text").GetComponent<Text>().text = "-" + attack;

                        if (AttackLeft(tile2.Value.Health, attack))
                        {
                            attack = attack - tile2.Value.Health;
                            tile2.Value.Health = 0;
                            defendingPlayer.GetComponent<PlayerPower>().currentPower -= attack;
                            totalAmount += attack;
                        }
                        else
                        {
                            tile2.Value.Health -= attack;
                            break;
                        }
                    }
                }
            }

            if (tile1.Value != null &&
                !dealtDamage)
            {
                defendingPlayer.GetComponent<PlayerPower>().currentPower -= tile1.Value.Attack;
                totalAmount += tile1.Value.Attack;
            }
        }

        if (totalAmount > 0)
        {
            defendingPlayer.transform.FindChild("HitMarker").localScale = new Vector3(1, 1, 1);
            defendingPlayer.transform.FindChild("HitMarker").GetComponent<Image>().color = new Color(.8f, .2f, .2f);
            defendingPlayer.transform.FindChild("HitMarker").FindChild("Text").GetComponent<Text>().text = "-" + totalAmount;
        }
    }

    public void DestroyBuilding(GameObject player)
    {
        bool repeat = true;

        while (repeat)
        {
            bool noBuildings = true;

            foreach (KeyValuePair<GameObject, Building> tile in player.transform.FindChild("City").GetComponent<Buildings>().tiles)
            {
                if (tile.Value != null)
                {
                    noBuildings = false;
                }

                if (tile.Value != null &&
                    repeat &&
                    Random.Range(0, 10) == 1)
                {
                    player.GetComponent<PlayerPower>().powerPerTurn += tiles[tile.Key].EnergyConsumption;
                    tiles[tile.Key] = null;
                    repeat = false;
                    break;
                }
            }

            if (noBuildings)
            {
                repeat = false;
            }
        }
    }

    public void BuffBuilding(GameObject player, Card card)
    {
        bool repeat = true;

        while (repeat)
        {
            bool noBuildings = true;

            foreach (KeyValuePair<GameObject, Building> tile in player.transform.FindChild("City").GetComponent<Buildings>().tiles)
            {
                if (tile.Value != null)
                {
                    noBuildings = false;
                }

                if (tile.Value != null &&
                    repeat &&
                    Random.Range(0, 10) == 1)
                {
                    tile.Value.Health += card.Health;
                    tile.Value.Attack += card.Attack;
                    tile.Value.Defense += card.Defense;

                    if (card.AbsorbAttack ||
                        card.AttackBuilding)
                    {
                        tile.Value.AbsorbAttack = card.AbsorbAttack;
                        tile.Value.AttackBuilding = card.AttackBuilding;
                    }

                    repeat = false;
                }
            }

            if (noBuildings)
            {
                repeat = false;
            }
        }
    }

    private int CalcDamage(int attack, int defense)
    {
        var total = attack - defense;

        if (total <= 0)
        {
            total = 0;
        }

        return total;
    }

    private bool AttackLeft(int health, int attack)
    {
        var total = health - attack;

        if (health < 0)
        {
            return true;
        }

        return false;
    }

    public bool BuildBuilding(Card card)
    {
        foreach (KeyValuePair<GameObject, Building> tile in tiles)
        {
            if (tile.Value == null)
            {
                Debug.Log(tile.Key);

                Building newBuilding = new Building() { Health = card.Health, Attack = card.Attack, Defense = card.Defense, Image = card.BuildingImage, AbsorbAttack = card.AbsorbAttack, AttackBuilding = card.AttackBuilding, EnergyConsumption = card.EnergyConsumption };

                tiles[tile.Key] = newBuilding;

                return true;
            }
        }

        return false;
    }
}
