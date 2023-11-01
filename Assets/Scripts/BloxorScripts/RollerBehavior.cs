using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerBehavior : MonoBehaviour
{
    
    public Transform pivotPoint;
    public Transform block;
    public LayerMask bloxorLevel;
    public float rollTime = 1f; 
    private bool inputActive;

    private void Awake()
    {
        inputActive = false;
    }
    
    private void Roll()
    {
        StartCoroutine(RollToDirection);
    }

    private IEnumerator RollToDirection()
    {
        if (!inputActive)
        {
            inputActive = true;
            float angle = 90f;
            
            // Vector3 axis = GetAxis(rollDirection);
            // Vector3 directionVector = GetDirectionVector(rollDirection);
            // Vector2 pivotOffset = GetPivotOffset(rollDirection);

            pivot.position = transform.position + (directionVector * pivotOffset.x) + (Vector3.down * pivotOffset.y);

            //simulate before the action in order to get an ideal result
            CopyTransformData(transform, ghostPlayer);
            ghostPlayer.RotateAround(pivot.position, axis, angle);

            float elapsedTime = 0f;

            while (elapsedTime < rollDuration)
            {
                elapsedTime += Time.deltaTime;

                transform.RotateAround(pivot.position, axis, (angle * (Time.deltaTime / rollDuration)));
                yield return null;
            }

            CopyTransformData(ghostPlayer, transform);

            isRolling = false;
        }
        
    }

    public void CopyTransformData(Transform source, Transform target)
    {
        target.localPosition = source.localPosition;
        target.localEulerAngles = source.localEulerAngles;
    }

    
    // private Vector3 GetAxis(Direction direction)
    // {
    //     switch (direction)
    //     {
    //         case Direction.Left:
    //             return Vector3.forward;
    //         case Direction.Up:
    //             return Vector3.right;
    //         case Direction.Right:
    //             return Vector3.back;
    //         case Direction.Down:
    //             return Vector3.left;
    //         default:
    //             return Vector3.zero;
    //     }
    // }
    //
    // private Vector3 GetDirectionVector(Direction direction)
    // {
    //     switch (direction)
    //     {
    //         case Direction.Left:
    //             return Vector3.left;
    //         case Direction.Up:
    //             return Vector3.forward;
    //         case Direction.Right:
    //             return Vector3.right;
    //         case Direction.Down:
    //             return Vector3.back;
    //         default:
    //             return Vector3.zero;
    //     }
    // }
    //
    // private Vector2 Offset(Direction direction)
    // {
    //     Vector2 offset = Vector2.zero;
    //     
    //     Vector2 center = transform.GetComponent<BoxCollider>().size / 2f;
    //
    //     RaycastHit hit;
    //     if (Physics.Raycast(transform.position, transform.up, out hit, 100f, contactWallLayer))
    //     {
    //         switch (hit.collider.name)
    //         {
    //             case "X":
    //                 if (direction == Direction.Left || direction == Direction.Right)
    //                     pivotOffset = new Vector2(center.y, center.x);
    //                 else
    //                     offset = Vector2.one * center.x;
    //                 break;
    //             case "Y":
    //                 pivotOffset = center;
    //                 break;
    //             case "Z":
    //                 if (direction == Direction.Up || direction == Direction.Down)
    //                     pivotOffset = new Vector2(center.y, center.x);
    //                 else
    //                     pivotOffset = Vector2.one * center.x;
    //                 break;
    //         }
    //     }
    //     return pivotOffset;
    // }

    public Vector3 getOffsetPoint()
    {
        //Probably do something with raycasting, will require premade empty objects to serve as points
    }
}