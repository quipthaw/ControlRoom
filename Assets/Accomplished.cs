using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accomplished : MonoBehaviour
{
    public ImgsFillDynamic ImgsFD;
    public GameObject go;
    private void Update()
    {
        // Just Test >___<~*
        this.ImgsFD.SetValue(Random.Range(0F, 0.7F), false, Random.Range(1F, 2F));
        go.SetActive(true);
    }

}
