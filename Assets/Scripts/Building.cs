using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building {

    public int Health { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public Sprite Image { get; set; }
    public int EnergyConsumption { get; set; }

    public bool AttackBuilding { get; set; }
    public bool AbsorbAttack { get; set; }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
