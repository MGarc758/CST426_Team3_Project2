using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathLayerScript : MonoBehaviour
{
    public GameObject bloxorGameManager;
    private void Awake()
    {
        Physics.IgnoreLayerCollision(8, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 7)
        {
            bloxorGameManager.GetComponent<BloxorGameManager>().Respawn(true);
        }
    }
}
