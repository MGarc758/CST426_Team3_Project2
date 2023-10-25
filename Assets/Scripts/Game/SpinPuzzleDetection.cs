using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinPuzzleDetection : Subject
{
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Trigger")
        {
            NotifyObservers(Puzzles.SpinPuzzleIncrement);
        }

    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Trigger")
        {
            NotifyObservers(Puzzles.SpinPuzzleDecrement);
        }

    }
    
    


}
