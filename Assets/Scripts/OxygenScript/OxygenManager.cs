using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenManager : MonoBehaviour
{
    public static OxygenManager oxygenManager { get; private set; }
    
    public UnitOxygen _playerOxygen = new UnitOxygen(300, 300);

    void Awake()
    {
        if (oxygenManager != null && oxygenManager != this)
        {
            Destroy(this);
        }
        else
        {
            oxygenManager = this;
        }
    }
}
