using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 20f;
    public AudioSource bubble;
    public AudioSource yay;
    public MoveRods rods;
    public Accomplished acc;
    public TestScript foo;

    [SerializeField] Text countdownText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0.0");
        if(currentTime<=0){
            currentTime= 0;
            bubble.enabled = false;
            yay.enabled = true;
            foo.enabled = false;
            acc.enabled = true;
        }
    }
}
