using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public InventoryItemData referenceItem;

    public Canvas winCanvas;

    private BoxCollider _boxCollider;

    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider>();
        _boxCollider.isTrigger = true;
        
    }

    private void OnTriggerEnter(Collider other)
    {
       
        var player = other.transform.GetComponent<PlayerMovement>();

        if (player)
        {
            OnHandlePickupItem();
        }
    }

    public void OnHandlePickupItem()
    {
        ShowWinCanvas();
        Destroy(gameObject);
    }
    
     private void ShowWinCanvas()
    {
        if (winCanvas != null)
        {
            winCanvas.gameObject.SetActive(true);
        }

    }
}
