using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public FuseBehavior fuseSlot1;
    public FuseBehavior fuseSlot2;
    public FuseBehavior fuseSlot3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fuseSlot1.getReplaced() && fuseSlot2.getReplaced() && fuseSlot3.getReplaced())
        {
            Debug.Log("You Win!");
        }
    }
}
