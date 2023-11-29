using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitOxygen
{
    // Fields
    int _currentOxygen;
    int _currentMaxOxygen;

    // Properties
    public int Oxygen
    {
        get
        {
            return _currentOxygen;
        }
        set
        {
            _currentOxygen = value;
        }
    }

    public int MaxOxygen
    {
        get
        {
            return _currentMaxOxygen;
        }
        set
        {
            _currentMaxOxygen = value;
        }
    }


    // Constructor
    public UnitOxygen(int oxygen, int maxOxygen)
    {
        _currentOxygen = oxygen;
        _currentMaxOxygen = maxOxygen;
    }

    // Methods
    public void OxygenLost(int dmgAmount)
    {
        if (_currentOxygen > 0)
        {
            _currentOxygen -= dmgAmount;
        }
            
    }

    public void OxygenGain(int healAmount)
    {
        if (_currentOxygen > 0)
        {
            _currentOxygen += healAmount;
        }

        if (_currentOxygen > _currentMaxOxygen)
        {
            _currentOxygen = _currentMaxOxygen;
        }
    }
}
