using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{

    public FuseBehavior fuseSlot1;
    public FuseBehavior fuseSlot2;
    public FuseBehavior fuseSlot3;
    public FuseBehavior fuseSlot4;
    public FuseBehavior fuseSlot5;
    public FuseBehavior fuseSlot6;


    //Win handling stuff
    public AudioSource yay;
    public AudioSource boo;
    public GameObject staticScreen;
    public GameObject winScreen;
    public GameObject loseScreen;
    private bool winable;
    private bool timerStarted = false;

    float currentTime = 4000000f;
    float startingTime = 45f;

    // Start is called before the first frame update
    void Start()
    {
        winable = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (checkMovementFinished())
        {
            timerStarted = true;
        }

        if(timerStarted == true && currentTime == 4000000f)
        {
            currentTime = startingTime;
        }
        if(currentTime != 4000000f && winable)
        {
            currentTime -= 1 * Time.deltaTime;
            Debug.Log(currentTime.ToString("0.0"));
            if (currentTime <= 0 )
            {
                winable = false;
                boo.enabled = true;
                boo.Play();
                staticScreen.SetActive(false);
                loseScreen.SetActive(true);
            }
        }

        if (winable)
        {
            if (checkReplaced())
            {
                timerStarted = false;
                yay.enabled = true;
                yay.Play();
                staticScreen.SetActive(false);
                winScreen.SetActive(true);
            }
        }
    }

    bool checkReplaced()
    {
        if(fuseSlot1.getReplaced() && fuseSlot2.getReplaced() && fuseSlot3.getReplaced() && fuseSlot4.getReplaced()
            && fuseSlot5.getReplaced() && fuseSlot6.getReplaced()) {
        return true;
        }
        else
        { return false; }
    }

    bool checkMovementFinished()
    {
        if(fuseSlot1.getMovementFinished() || fuseSlot2.getMovementFinished() || fuseSlot3.getMovementFinished()
            || fuseSlot4.getMovementFinished() || fuseSlot5.getMovementFinished() || fuseSlot6.getMovementFinished()) {
            return true;
        }
        else
        {
            return false;
        }
    }
}
