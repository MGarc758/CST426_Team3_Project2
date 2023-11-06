using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPOI : MonoBehaviour
{
    [SerializeField] private Transform _parent;
    [SerializeField] private Transform _lookAtTarget;
    [SerializeField] private float lookSpeed = 1f;

    private bool lookAt;

    private Transform _lookAtTransform;
    private Vector3 _targetPostion;
    
    


    // Update is called once per frame
    void Update()
    {
        if (!lookAt)
        {
            _targetPostion = _parent.position + _parent.forward * 2f + new Vector3(0f, 2f, 0f);
        }

        _lookAtTarget.transform.position = Vector3.Lerp(_lookAtTarget.transform.position, _targetPostion, Time.deltaTime * lookSpeed);

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_lookAtTarget != null && _lookAtTarget.TryGetComponent<ItemObject>(out ItemObject item))
            {
                item.OnHandlePickupItem();
            }
        }
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.GetComponent<PointOfInterest>())
        {
            _targetPostion = collider.transform.position;
            lookAt = true;
        }
    }

    public void OnTriggerExit(Collider collider)
    {
        lookAt = false;
    }
}
