using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinButton2 : MonoBehaviour
{
    public GameObject centerCircle;
    public float rotationSpeed = 10f;

    private void Update()
    {
        float rotationDirection = Input.GetAxis("Vertical"); // Get input from left and right arrow keys

        if (rotationDirection != 0)
        {
            RotateCenterCircle(rotationSpeed * rotationDirection);
        }
    }

    private void RotateCenterCircle(float speed)
    {
        centerCircle.transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }
}
