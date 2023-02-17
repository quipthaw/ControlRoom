using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextUpdater : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public LeverRotationValue lrv;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float value = lrv.getRotationValue(); 
        textMeshPro.SetText(value.ToString("0.00"));
    }
}
