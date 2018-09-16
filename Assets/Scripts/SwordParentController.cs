using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordParentController : MonoBehaviour
{
    private Animator animatorComponent;

    private const string IDLE = "Idle";
    private const string STAB = "Stab";
    private const string CHOP = "Chop";

    //audio
    public string wooshPath = "event:/Wooshes";
    FMOD.Studio.EventInstance wooshEvent;
    public string chopPath = "event:/GruntsHigh";
    FMOD.Studio.EventInstance gruntEvent;

    private string controller;

    void Awake()
    {
        animatorComponent = GetComponent<Animator>();
        wooshEvent = FMODUnity.RuntimeManager.CreateInstance(wooshPath);
        gruntEvent = FMODUnity.RuntimeManager.CreateInstance(chopPath);
    }

    public void Stab()
    {
        if (IsIdle())
        {
            animatorComponent.Play(STAB);
            wooshEvent.start();

        }
    }

    public void Chop()
    {
        if (IsIdle())
        {
            animatorComponent.Play(CHOP);
            wooshEvent.start();
            gruntEvent.start();

        }
    }

    public bool IsIdle()
    {
        return animatorComponent.GetCurrentAnimatorStateInfo(0).IsName(IDLE);
    }
}