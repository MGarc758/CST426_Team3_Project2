using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 targetPosition;
    private float transitionSpeed;
    public bool isMoving;

    public bool IsMoving => isMoving;

    public void MoveToPosition(Vector3 newPosition, float speed)
    {
        targetPosition = newPosition;
        transitionSpeed = speed;
        isMoving = true;
    }

    private void Update()
    {
        // Smoothly move the empty GameObject (with CameraFollow script) to the target position
        Debug.Log("Entered Camera Follow Update");
        if (isMoving)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, transitionSpeed * Time.deltaTime);

        }

        Debug.Log(Vector3.Distance(transform.position, targetPosition));
        // Check if the camera has reached the target position
        if (Vector3.Distance(transform.position, targetPosition) < .1f)
        {
            isMoving = false;
        }
    }
}