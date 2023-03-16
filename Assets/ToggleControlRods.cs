using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleControlRods : MonoBehaviour
{

    public MoveRods controlRods;

    // Update is called once per frame
    void Update()
    {
        float angle = this.GetComponent<HingeJoint>().angle;
        Debug.Log(angle);
        if (angle > 0)
        {
            controlRods.enabled = true;
        }
        else
        {
            controlRods.enabled = false;
        }
    }
}
