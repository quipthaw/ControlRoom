using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XenonBuildup : MonoBehaviour
{
    public float rate = 0.005f;

    private float xenonAmount = 0.0f;
    private Image xenonBar;
    public AudioSource alarmAudio;
    public AudioSource releaseAudio;

    void Start()
    {
        xenonBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        xenonAmount += rate * Time.deltaTime;
        xenonBar.fillAmount = xenonAmount;

        if (!alarmAudio.isPlaying && xenonBar.fillAmount >= 0.99f)
        {
            alarmAudio.Play();
        }
    }

    public void Release()
    {
        if (alarmAudio.isPlaying)
        {
            alarmAudio.Stop();
        }

        xenonAmount = 0.0f;
        releaseAudio.Play();
    }
}
