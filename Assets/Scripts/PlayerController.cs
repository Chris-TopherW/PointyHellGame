using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public SwordParentController swordParentController;
    public int maxHealth = 100;

    private int health;
    private bool dead;

    private Vector3 initialPosition;
    private Quaternion initialRotation;

    void Start () {
        health = maxHealth;

        initialPosition = transform.position;
        initialRotation = transform.rotation;
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
    }

    public bool Dead()
    {
        return health <= 0;
    }

    public void Hit()
    {
        health -= 10;
    }

    public void Reset()
    {
        health = maxHealth;
        transform.position = initialPosition;
        transform.rotation = initialRotation;
    }
}
