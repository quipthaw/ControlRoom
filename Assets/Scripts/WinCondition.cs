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
    public GameObject staticScreen;
    public GameObject winScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (checkReplaced())
        {
            yay.enabled = true;
            staticScreen.SetActive(false);
            winScreen.SetActive(true);
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
}
