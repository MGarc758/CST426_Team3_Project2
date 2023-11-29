using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GravityMaze : MonoBehaviour
{
    public GameObject maze;

    [SerializeField] 
    private Vector3 rotation;
    [SerializeField]
    private float speed = 20f;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rotation = Vector3.forward;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rotation = Vector3.back;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            rotation = Vector3.right;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            rotation = Vector3.left;
        }
        else
        {
            rotation = Vector3.zero;
        }
        
        maze.transform.Rotate(rotation * (speed * Time.deltaTime));
        
    }
}
