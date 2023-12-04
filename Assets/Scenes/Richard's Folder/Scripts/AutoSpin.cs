using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSpin : MonoBehaviour
{
    public Transform[] rings; // Array of the ring GameObjects
    public Transform[] visibleCubes; // Array of the visible cube GameObjects
    public Transform[] triggerCubes; // Array of the trigger cube GameObjects
    public float rotationSpeed = 30f;
    public float snapMargin = 1f; // Adjust this threshold as needed
    
    private bool[] isMoving; // To control the rotation of each ring
    private int currentRingIndex; // To track the current ring

    private void Start()
    {
        // Initialize the array and set all rings to be initially moving
        isMoving = new bool[rings.Length];
        for (int i = 0; i < isMoving.Length; i++)
        {
            isMoving[i] = true;
        }
        currentRingIndex = 0;
        float yRotation1 = Random.Range(-300f, 300f);
        float yRotation2 = Random.Range(-300f, 300f);
        float yRotation3 = Random.Range(-300f, 300f);
        rings[0].GetComponent<Transform>().eulerAngles = new Vector3(0, yRotation1, 0);
        rings[1].GetComponent<Transform>().eulerAngles = new Vector3(0, yRotation2, 0);
        rings[2].GetComponent<Transform>().eulerAngles = new Vector3(0, yRotation3, 0);
    }

    private void Update()
    {
        for (int i = 0; i < rings.Length; i++)
        {
            if (isMoving[i])
            {
                // Rotate the ring
                rings[i].Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentRingIndex < rings.Length)
            {
                // Stop the current ring
                isMoving[currentRingIndex] = false;

                // Check if the visible cubes on the current ring are aligned with the trigger cubes
                bool cubesAligned = AreCubesAligned(rings[currentRingIndex]);

                if (cubesAligned)
                {
                    // Move to the next ring if the cubes are aligned
                    currentRingIndex++;
                    rotationSpeed += rotationSpeed + 30;

                    // If all rings have been stopped and checked, you can add more actions here
                    if (currentRingIndex >= rings.Length)
                    {
                        Debug.Log("Puzzle completed!");
                        // You can add more actions here if needed.
                    }
                    else
                    {
                        isMoving[currentRingIndex] = true; // Start the next ring
                    }
                }
                else
                {
                    // Not all cubes are aligned, so allow another attempt
                    isMoving[currentRingIndex] = true;
                }
            }
        }
    }

    private bool AreCubesAligned(Transform ring)
    {
        // Check if the visible cubes on the current ring are aligned with the trigger cubes
        for (int i = 0; i < visibleCubes.Length; i += 2)
        {
            Transform cube1 = ring.GetChild(0);
            //Transform cube2 = ring.GetChild(1);

            // Find the corresponding trigger cubes
            Transform triggerCube1 = triggerCubes[i];
            //Transform triggerCube2 = triggerCubes[i + 1];

            if (Vector3.Distance(cube1.position, triggerCube1.position) > snapMargin)// ||
                //Vector3.Distance(cube2.position, triggerCube2.position) > snapMargin)
            {
                return false; // At least one cube is not aligned
            }
        }
        return true; // All cubes are aligned
    }
}
