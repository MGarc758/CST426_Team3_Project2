using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenBar : MonoBehaviour
{
    private Slider _oxygenSlider;
    
    // Start is called before the first frame update
    void Awake()
    {
        _oxygenSlider = GetComponent<Slider>();
    }

    public void setMaxOxygen(int maxOxygen)
    {
        _oxygenSlider.maxValue = maxOxygen;
        _oxygenSlider.value = maxOxygen;
    }

    public void setOxygen(int oxygen)
    {
        _oxygenSlider.value = oxygen;
    }
}
