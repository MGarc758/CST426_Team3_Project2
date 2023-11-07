using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public InventoryItemData referenceItem;

    private BoxCollider _boxCollider;

    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider>();
        _boxCollider.isTrigger = true;
        
    }

    private void OnTriggerEnter(Collider other)
    {
       
        var player = other.transform.GetComponent<PlayerMovement>();

        if (!player)
        {
            return;
        }
        else
        {
            OnHandlePickupItem();
        }
    }

    public void OnHandlePickupItem()
    {
        InventorySystem.current.Add(referenceItem);
        Destroy(gameObject);
    }
}
