using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public SwordParentController swordParentController;
    public int maxHealth = 100;
    public Text healthText;

    private int health;

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

        if (healthText != null)
        {
            healthText.text = health + " hp remaining";
        }
    }

    public bool IsDead()
    {
        return health <= 0;
    }

    public void Hit(int damage, Vector3 direction)
    {
        health = Mathf.Max(health - damage, 0);

        // Doesn't work becuase the rigidbody has to be kinematic :(
        //Rigidbody rb = GetComponent<Rigidbody>();
        //rb.AddForce(direction * 100, ForceMode.Impulse);
    }

    public void Reset()
    {
        health = maxHealth;
        transform.position = initialPosition;
        transform.rotation = initialRotation;
    }
}
