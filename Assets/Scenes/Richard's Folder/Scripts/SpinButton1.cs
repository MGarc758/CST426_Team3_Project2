using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinButton1 : MonoBehaviour
{
    public GameObject outermostCircle;
    public GameObject innermostCircle;
    public float rotationSpeed = 10f;

    private void Update()
    {
        float rotationDirection = Input.GetAxis("Horizontal"); // Get input from left and right arrow keys

        if (rotationDirection != 0)
        {
            RotateCircles(rotationSpeed * rotationDirection);
        }
    }

    private void RotateCircles(float speed)
    {
        outermostCircle.transform.Rotate(Vector3.up * speed * Time.deltaTime);
        innermostCircle.transform.Rotate(Vector3.down * speed * Time.deltaTime);
    }
}
