using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsScript : MonoBehaviour
{
    //roundtimer variable
    public int roundTime = 0;
    //audiomixer object
    public AudioMixer audioMixer;
    //manager object
    public GameObject manager;
    //Input object
    public Text timerInput;

    private void Start() {
        //sets the manager
        manager = GameObject.Find("Manager");
    }

    //function for controlling the volume through the mixer, with the slider
    public void SetVolume (float volume){
        audioMixer.SetFloat("Volume", volume);
    }
    //sends the timer from this script to the manager
    public void SetRoundTimer() {
        roundTime = int.Parse(timerInput.text);
        manager.GetComponent<ManagerScript>().setTimer(roundTime);
    }
}
