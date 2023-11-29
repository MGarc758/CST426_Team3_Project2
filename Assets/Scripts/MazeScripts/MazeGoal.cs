using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGoal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Maze Finished");
        }
        
    }
}
