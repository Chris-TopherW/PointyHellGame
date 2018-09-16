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
        musicEvent.setVolume(0.5f);
        musicEvent.start();

	}

    private void Update()
    {
        musicEvent.setParameterValue("Section", section);
    }

    //1 is intro screen, 3 is main loop. 2.0 to 3 can be lerped for music fade in.
    public void setMusicParam(float param)
    {
        section = param;
    }

    //void PlaySound(string path)
    //{
    //		FMODUnity.RuntimeManager.PlayOneShot(path, GetComponent<Transform>().position);

    //}
}
