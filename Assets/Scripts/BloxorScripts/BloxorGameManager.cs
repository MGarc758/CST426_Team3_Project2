using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloxorGameManager : MonoBehaviour
{
    public GameObject firstLayer;
    public GameObject secondLayer;
    public GameObject thirdLayer;
    public GameObject blockObjectPrefab;
    public GameObject rotationObjectPrefab;
    public GameObject blk;
    public GameObject rtCube;
    public GameObject doorToDestroy;
    public GameObject terminal;
    
    private string currentLayer;

    public void blob()
    {
        currentLayer = "First";
        blk = Instantiate(blockObjectPrefab);
        rtCube = Instantiate(rotationObjectPrefab);

        blk.GetComponent<RollerBehavior>().rotationPointObject = rtCube;
    }

    public void victorySwap()
    {
        switch (currentLayer)
        {
            case "First":
                firstLayer.SetActive(false);
                secondLayer.SetActive(true);
                currentLayer = "Second";
                break;
            
            case "Second":
                secondLayer.SetActive(false);
                thirdLayer.SetActive(true);
                currentLayer = "Third";
                break;
            
            case "Third":
                thirdLayer.SetActive(false);
                firstLayer.SetActive(true);
                currentLayer = "First";
                FinalVictory();
                break;
        }

        Respawn(false);
    }

    public void FinalVictory()
    {
       Destroy(doorToDestroy);
       terminal.GetComponent<RedMoniterScript>().ToggleCameraPosition();
       //not sure yet
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn(bool dead)
    {
        if (dead)
        {
            currentLayer = "First";
            secondLayer.SetActive(false);
            thirdLayer.SetActive(false);
            firstLayer.SetActive(true);
        }

        Destroy(blk);
        Destroy(rtCube);
        
        blk = Instantiate(blockObjectPrefab);
        rtCube = Instantiate(rotationObjectPrefab);

        blk.GetComponent<RollerBehavior>().rotationPointObject = rtCube;
    }
    
}
