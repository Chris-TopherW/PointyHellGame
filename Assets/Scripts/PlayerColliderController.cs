using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderController : MonoBehaviour {

    public PlayerController playerController;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Sword" && collider.gameObject.tag != tag && !collider.gameObject.GetComponent<SwordController>().ParentIdle())
        {
            playerController.Hit();
        }
    }
}
