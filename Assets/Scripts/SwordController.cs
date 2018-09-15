using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour {

    public GameObject parent;

    public float velocity = 0.1f;

    private bool animating = false;
    private float animationPercent = 0.0f;

    // Use this for initialization
    void Start () {
        //startingRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetButtonDown("Fire1")) {
            animating = true;
            animationPercent = 0.0f;
        }

        if (animating) {
            animationPercent += velocity;
        }

        float t = animationPercent < 0.5f ? Map(animationPercent, 0.0f, 0.5f, 0.0f, 1.0f) : Map(animationPercent, 0.5f, 1.0f, 1.0f, 0.0f);

        transform.rotation = Quaternion.Lerp(
            parent.transform.rotation,
            parent.transform.rotation * Quaternion.AngleAxis(180, Vector3.up),
            t
        );

        if (animating && animationPercent >= 1.0f) {
            animating = false;
            animationPercent = 0.0f;
        }
    }

    public float Map(float x, float in_min, float in_max, float out_min, float out_max)
    {
        return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
    }

}
