using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public SwordParentController swordParentController;
    public int maxHealth = 100;
    public Text healthText;
    public GameObject start;

    private int health;

    private Vector3 initialPosition;
    private Vector3 initialRotation;

    void Start () {
        health = maxHealth;

        initialPosition = start.transform.position;
        initialRotation = start.transform.eulerAngles;
    }
	
	void Update () {
        if (Input.GetButtonDown(name + " Fire1"))
        {
            swordParentController.Stab();
        }

        if (Input.GetButtonDown(name + " Fire2"))
        {
            swordParentController.Chop();
        }

        if (healthText != null)
        {
            healthText.text = health + " HP remaining";
        }
    }

    public bool IsDead()
    {
        return health <= 0;
    }

    public void Hit(int damage)
    {
        health = Mathf.Max(health - damage, 0);
    }

    public void Reset()
    {
        health = maxHealth;
        transform.position = initialPosition;
        transform.eulerAngles = initialRotation;
    }
}
