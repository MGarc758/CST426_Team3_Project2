using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class RollerBehavior : MonoBehaviour
{
    public int rollSpeed = 250;
    private bool moving = false;
    public LayerMask detectionWalls;
    public GameObject rotationPointObject;

    private void Update()
    {
        if (moving == true)
        {
            return;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            StartCoroutine(RollRectangle(Vector3.right, Vector3.back));
        } 
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            StartCoroutine(RollRectangle(Vector3.left, Vector3.forward));
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            StartCoroutine(RollRectangle(Vector3.forward, Vector3.right));
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            StartCoroutine(RollRectangle(Vector3.back, Vector3.left));
        }
        
    }

    IEnumerator RollRectangle(Vector3 rollDirection, Vector3 axisOfRotation)
    {
        moving = true;
        //Vector3 axisOfRotation = Vector3.Cross(Vector3.up, rollDirection);
        Vector3 pivotPoint = Offset(rollDirection);

        rotationPointObject.transform.position = pivotPoint;
        transform.SetParent(rotationPointObject.transform);

        float angleToBeRotated = 90f;

        while (angleToBeRotated > 0)
        {
            float angleOfRotation = Mathf.Min(Time.deltaTime * rollSpeed, angleToBeRotated);
            rotationPointObject.transform.RotateAround(pivotPoint, axisOfRotation, angleOfRotation);
            angleToBeRotated -= angleOfRotation;
            yield return null;
        }
        
        rotationPointObject.transform.DetachChildren();
        rotationPointObject.transform.localPosition = Vector3.zero;
        rotationPointObject.transform.localEulerAngles = Vector3.zero;
        moving = false;
    }
    
    private Vector3 Offset(Vector3 dir)
    {
        Vector3 offset = Vector2.zero;
        
        Vector3 center = transform.position;
    
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.up, out hit, 100f, detectionWalls))
        {
            switch (hit.collider.name)
            {
                case "X":
                    // if (dir.Equals(Vector3.left) || dir.Equals(Vector3.right))
                    //     offset = new Vector2(center.y, center.x);
                    // else
                    //     offset = Vector2.one * center.x;
                    if (dir.Equals(Vector3.back))
                    {
                        offset = new Vector3(center.x, center.y - 0.5f, center.z - 0.5f);
                    }

                    if (dir.Equals(Vector3.forward))
                    {
                        offset = new Vector3(center.x, center.y - 0.5f, center.z + 0.5f);
                    }
                    
                    if (dir.Equals(Vector3.left))
                    {
                        offset = new Vector3(center.x - 1f, center.y - 0.5f, center.z);
                    }

                    if (dir.Equals(Vector3.right))
                    {
                        offset = new Vector3(center.x + 1f, center.y - 0.5f, center.z);
                    }
                    break;
                
                case "Y":
                    if (dir.Equals(Vector3.back))
                    {
                        offset = new Vector3(center.x, center.y - 1f, center.z - 0.5f);
                    }

                    if (dir.Equals(Vector3.forward))
                    {
                        offset = new Vector3(center.x, center.y - 1f, center.z + 0.5f);
                    }
                    
                    if (dir.Equals(Vector3.left))
                    {
                        offset = new Vector3(center.x - 0.5f, center.y - 1f, center.z);
                    }

                    if (dir.Equals(Vector3.right))
                    {
                        offset = new Vector3(center.x + 0.5f, center.y - 1f, center.z);
                    }
                    break;
                
                case "Z":
                    // if (dir.Equals(Vector3.forward) || dir.Equals(Vector3.back))
                    //     offset = new Vector2(center.y, center.x);
                    // else
                    //     offset = Vector2.one * center.x;
                    if (dir.Equals(Vector3.back))
                    {
                        offset = new Vector3(center.x, center.y - 0.5f, center.z - 1f);
                    }

                    if (dir.Equals(Vector3.forward))
                    {
                        offset = new Vector3(center.x, center.y - 0.5f, center.z + 1f);
                    }
                    
                    if (dir.Equals(Vector3.left))
                    {
                        offset = new Vector3(center.x - 0.5f, center.y - 0.5f, center.z);
                    }

                    if (dir.Equals(Vector3.right))
                    {
                        offset = new Vector3(center.x + 0.5f, center.y - 0.5f, center.z);
                    }
                    break;
            }
        }
        return offset;
    }
    //
    // public Vector3 getOffsetPoint()
    // {
    //     //Probably do something with raycasting, will require premade empty objects to serve as points
    // }

    public bool CheckIfVertical()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.up, out hit, 100f, detectionWalls))
        {
            switch (hit.collider.name)
            {
                case "X":
                    return false;

                case "Y":
                    return true;

                case "Z":
                    return false;
            }
        }

        return false;
    }
}