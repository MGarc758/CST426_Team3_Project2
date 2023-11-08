using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloxorGameManager : MonoBehaviour
{
    public GameObject firstLayer;

    public GameObject secondLayer;

    public GameObject thirdLayer;

    public GameObject blockObject;

    private string currentLayer;

    private void Awake()
    {
        currentLayer = "First";
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

        blockObject.transform.position = new Vector3(9f, 2.1f, 6f);
        blockObject.transform.eulerAngles = Vector3.zero;
    }

    public void FinalVictory()
    {
        Debug.Log("YAY\n");
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
}
