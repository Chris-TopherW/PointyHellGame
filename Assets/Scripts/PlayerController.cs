using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject swordParent;
    public int maxHealth = 100;

    private int health;

	void Start () {
        health = maxHealth;
	}
	
	void Update () {
        if (Input.GetButtonDown(name + " Fire1"))
        {
            swordParent.GetComponent<SwordController>().Stab();
        }

        if (Input.GetButtonDown(name + " Fire2"))
        {
            swordParent.GetComponent<SwordController>().Chop();
        }
    }
}
