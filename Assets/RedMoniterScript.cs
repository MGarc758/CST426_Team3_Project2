using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMoniterScript : MonoBehaviour
{
   public Transform terminalDestination; // Set the destination for the camera when entering the terminal
    public Transform originalStartingPosition; // Set the original starting position for the camera
    public float transitionTime = 2f; // Set the time it takes to transition to the destination
    public GameObject player; // Reference to the player GameObject
    private bool isPlayerLocked = false;
    private Vector3 currentCameraPosition;
    private PlayerMovement playerMovement;
    private CameraFollow cameraFollow;
    public GameObject puzzle;
    public GameObject camera;
    
    private void Start()
    {
        // Save the current camera position when the terminal script starts
        currentCameraPosition = player.transform.position;
        playerMovement = player.GetComponent<PlayerMovement>();
        cameraFollow = player.GetComponentInChildren<CameraFollow>();
    }

    private void Update()
    {
        // Check for player input to interact with the terminal when looking at it
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (IsPlayerLookingAtTerminal())
            {
                ToggleCameraPosition();
            }
        }

        // Check for player input to exit the terminal
        if (Input.GetKeyDown(KeyCode.E) && isPlayerLocked && !cameraFollow.IsMoving)
        {
            ToggleCameraPosition();
        }
    }

    public void ToggleCameraPosition()
    {
        if (!isPlayerLocked)
        {
            puzzle.SetActive(true);
            camera.GetComponent<MouseLook>().enabled = false;
            // Move the empty GameObject (with CameraFollow script) to the terminal destination
            cameraFollow.MoveToPosition(terminalDestination.position, transitionTime);
            // camera.transform.position = terminalDestination.position;
            camera.transform.rotation = terminalDestination.rotation;
            // Lock player movement
            playerMovement.LockPlayer();
            isPlayerLocked = true;
        }
        else
        {
            
            puzzle.transform.GetChild(4).GetComponent<BloxorGameManager>().Respawn(true);
            puzzle.SetActive(false);
            
            //camera.GetComponent<MouseLook>().enabled = true;
            // Move the empty GameObject (with CameraFollow script) to the original starting position
            cameraFollow.MoveToPosition(originalStartingPosition.position, transitionTime);
            // camera.transform.position = originalStartingPosition.position;
            // camera.transform.rotation = originalStartingPosition.rotation;
            
           // camera.transform.SetParent(player.transform);
            // player.transform.position = originalStartingPosition.position;
            // Unlock player movement after the camera finishes moving
            StartCoroutine(UnlockPlayerAfterDelay(transitionTime));

            isPlayerLocked = false;
        }
    }

    private bool IsPlayerLookingAtTerminal()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));

        if (Physics.Raycast(ray, out hit))
        {
            // Check if the hit object is the terminal
            if (hit.collider.gameObject == gameObject)
            {
                return true;
            }
        }

        return false;
    }

    private System.Collections.IEnumerator UnlockPlayerAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Unlock player movement
        playerMovement.UnlockPlayer();
    }
}
