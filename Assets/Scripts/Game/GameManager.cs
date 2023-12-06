using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, IObserver
{
    [SerializeField] private Subject _subject;
    [SerializeField] private Subject _subject1;
    [SerializeField] private Subject _subject2;
    [SerializeField] private Subject _subject3;
    [SerializeField] private Subject _subject4;
    [SerializeField] private Subject _subject5;
    public int count = 0;
    private GameObject oxygen;
    
    private void Awake()
    {
        oxygen = GameObject.Find("FirstPersonPlayer");
    }
    
    public void OnNotify(Puzzles puzzles)
    {
        switch (puzzles)
        {
            case(Puzzles.SpinPuzzleIncrement):
                count++;
                if (count == 6)
                {
                    oxygen.GetComponent<PlayerBehavior>().PlayerHeal(300);
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
        _subject3.AddObserver(this);
        _subject4.AddObserver(this);
        _subject5.AddObserver(this);
    }

    private void OnDisable()
    {
        _subject.RemoveObserver(this);
        _subject1.RemoveObserver(this);
        _subject2.RemoveObserver(this);
        _subject3.RemoveObserver(this);
        _subject4.RemoveObserver(this);
        _subject5.RemoveObserver(this);
    }
}
