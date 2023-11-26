using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBlockScript : MonoBehaviour
{
    public GameObject playerBlock;

    public GameObject layerManager;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("TRIGGERING");
        if (collision.gameObject.layer == 7)
        {
            if (collision.gameObject.GetComponent<RollerBehavior>().CheckIfVertical())
            {
                layerManager.GetComponent<BloxorGameManager>().victorySwap();
            }
        }
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.gameObject.name == "PuzzleRectangle")
    //     {
    //         if (playerBlock.GetComponent<RollerBehavior>().CheckIfVertical())
    //         {
    //             layerManager.GetComponent<BloxorGameManager>().victorySwap();
    //         }
    //     }
    // }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
