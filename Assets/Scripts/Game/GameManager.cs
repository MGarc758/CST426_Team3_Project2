using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, IObserver
{
    [SerializeField] private Subject _subject;
    [SerializeField] private Subject _subject1;
    [SerializeField] private Subject _subject2;
    public int count = 0;
    public void OnNotify(Puzzles puzzles)
    {
        switch (puzzles)
        {
            case(Puzzles.SpinPuzzleIncrement):
                count++;
                if (count == 3)
                {
                    Debug.Log("Unlocked the Door");
                }
                return;
            case(Puzzles.SpinPuzzleDecrement):
                count--;
                return;
            default:
                return;
        }
    }


    private void OnEnable()
    {
        _subject.AddObserver(this);
        _subject1.AddObserver(this);
        _subject2.AddObserver(this);
    }

    private void OnDisable()
    {
        _subject.RemoveObserver(this);
        _subject1.RemoveObserver(this);
        _subject2.RemoveObserver(this);
    }
}
