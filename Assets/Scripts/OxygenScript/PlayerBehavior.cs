using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{

    [SerializeField] private OxygenBar _oxygenBar;
    
    private WaitForSeconds refreshIntervalWait = new WaitForSeconds(1);

    private void Start()
    {
        StartCoroutine(OxygenDepletion());
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.H))
        {
            PlayerHeal(10);
            Debug.Log(OxygenManager.oxygenManager._playerOxygen.Oxygen);
        }
    }

    private void PlayerTakeDmg(int dmg)
    {
        OxygenManager.oxygenManager._playerOxygen.OxygenLost(dmg);
        
        _oxygenBar.setOxygen(OxygenManager.oxygenManager._playerOxygen.Oxygen);
    }

    private void PlayerHeal(int healing)
    {
        OxygenManager.oxygenManager._playerOxygen.OxygenGain(healing);
        
        _oxygenBar.setOxygen(OxygenManager.oxygenManager._playerOxygen.Oxygen);
    }

    IEnumerator OxygenDepletion()
    {
        while (true)
        {
            yield return refreshIntervalWait;
            PlayerTakeDmg(1);
            Debug.Log(OxygenManager.oxygenManager._playerOxygen.Oxygen); 
        }

    }
}