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
        if (isMoving)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, transitionSpeed * Time.deltaTime);

        }
        
        // Check if the camera has reached the target position
        if (Vector3.Distance(transform.position, targetPosition) < .5f)
        {
            isMoving = false;
        }
    }
}