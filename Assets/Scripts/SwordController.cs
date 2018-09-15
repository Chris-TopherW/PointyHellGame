using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{

    private Animator animatorComponent;
    private Renderer rendererComponent;

    private const string IDLE = "Idle";
    private const string STAB = "Stab";
    private const string CHOP = "Chop";

    void Awake()
    {
        animatorComponent = GetComponent<Animator>();
        rendererComponent = GetComponent<Renderer>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animatorComponent.Play(STAB);
        }

        if (Input.GetButtonDown("Fire2"))
        {
            animatorComponent.Play(CHOP);
        }
    }
}