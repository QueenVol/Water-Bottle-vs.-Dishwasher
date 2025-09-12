using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bottle : MonoBehaviour
{
    public float breakProgress = 1f;
    public Slider slider;

    private void Start()
    {
        
    }

    private void Update()
    {
        Debug.Log(breakProgress);
        slider.value = breakProgress;
    }
}
