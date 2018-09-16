using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderController : MonoBehaviour {

    public PlayerController playerController;

    //audio
    public string stabPath = "event:/Squelch";
    FMOD.Studio.EventInstance stabEvent;

    private void Awake()
    {
        stabEvent = FMODUnity.RuntimeManager.CreateInstance(stabPath);
    }

    void OnTriggerEnter(Collider collider)
    {
        GameObject other = collider.gameObject;

        if (other.name == "Sword" && other.tag != tag && !other.GetComponent<SwordController>().ParentIdle())
        {
            playerController.Hit(other.GetComponent<SwordController>().damage);
            stabEvent.start();
        }
    }
}
