using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class TestFMOD : MonoBehaviour {

	public string thePath = "event:/MainSong";
    [Range(1.0f, 4.0f)]
    public float section = 3.0f;
    FMOD.Studio.EventInstance musicEvent;

	private void Start() {
        musicEvent = FMODUnity.RuntimeManager.CreateInstance(thePath);
        musicEvent.start();

	}

    private void Update()
    {
        musicEvent.setParameterValue("Section", section);
    }

    //void PlaySound(string path)
    //{
    //		FMODUnity.RuntimeManager.PlayOneShot(path, GetComponent<Transform>().position);

    //}
}
