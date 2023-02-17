using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverRotationValue : MonoBehaviour
{
    public Vector3 AxisOfRotation = new Vector3(1, 0, 0);
    public HingeJoint HingeJoint;

    private float value;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        value = HingeJoint.angle;
    }

    public float getRotationValue()
    {
        return value;
    }
}
