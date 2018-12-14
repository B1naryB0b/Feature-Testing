using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Slider slider;

    public float drainRate = 5;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = slider.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = Time.deltaTime * drainRate;
    }
}
