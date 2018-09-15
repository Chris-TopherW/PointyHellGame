using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{

    private Animator animatorComponent;

    private const string IDLE = "Idle";
    private const string STAB = "Stab";
    private const string CHOP = "Chop";

    private string controller;

    void Awake()
    {
        animatorComponent = GetComponent<Animator>();
    }

    public void Stab()
    {
        if (IsIdle())
        {
            animatorComponent.Play(STAB);
        }
    }

    public void Chop()
    {
        if (IsIdle())
        {
            animatorComponent.Play(CHOP);
        }
    }

    bool IsIdle()
    {
        return animatorComponent.GetCurrentAnimatorStateInfo(0).IsName(IDLE);
    }
}