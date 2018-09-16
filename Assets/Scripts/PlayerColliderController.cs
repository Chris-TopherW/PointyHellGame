using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderController : MonoBehaviour {

    public PlayerController playerController;

    void OnTriggerEnter(Collider collider)
    {
        GameObject other = collider.gameObject;

        if (other.name == "Sword" && other.tag != tag && !other.GetComponent<SwordController>().ParentIdle())
        {
            playerController.Hit(other.GetComponent<SwordController>().damage);
        }
    }
}
