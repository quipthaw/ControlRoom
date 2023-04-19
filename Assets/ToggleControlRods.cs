using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleControlRods : MonoBehaviour
{

    public MoveRods controlRods;
    public AudioSource Sound;
    public CountdownTimer timer;
    public GameObject Screen;
    public GameObject info;

    // Update is called once per frame
    void Update()
    {
        float angle = this.GetComponent<HingeJoint>().angle;
        if (angle > 0)
        {
            controlRods.enabled = true;
            Sound.enabled = true;
            Screen.SetActive(true);
            info.SetActive(true);
            timer.enabled = true;

        }
        else
        {
            controlRods.enabled = false;
            Sound.enabled = false;
            Screen.SetActive(false);
            info.SetActive(false);
            timer.enabled = false;
        }
    }
}
