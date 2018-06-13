using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PuzzleProgressManager : MonoBehaviour {

    public static PuzzleProgressManager instance { get; private set; }

    public bool automaticallyEnterFirstInList;
    public string eventName = "Puzzle_time";
    public List<PuzzleProgressPoint> puzzleProgressPoints = new List<PuzzleProgressPoint>();
    public delegate void CheckPointReached();
    public CheckPointReached onCheckPointReached;
    

    [Header("Live data")]
    public PuzzleProgressPoint currentPoint;

	void Awake () {
        if(instance == null) {
            instance = this;
        }else {
            DestroyImmediate(this);
        }  
	}

    private void Start() {
        if (automaticallyEnterFirstInList) {
            puzzleProgressPoints[0].EnterPoint();
        }
        
    }

    

    public void PointReached(PuzzleProgressPoint newProgressPoint) {
        int count = 0;
        foreach(PuzzleProgressPoint progressPoint in puzzleProgressPoints) {
            if (progressPoint == newProgressPoint) {
                currentPoint = progressPoint;

                if(count >0)
                puzzleProgressPoints[count-1].ExitPoint();
            }
            count++;
        }

        if (onCheckPointReached!=null)
        {
            onCheckPointReached();
        }
        
    }



    private void OnDisable() {
        if(currentPoint != null)
        currentPoint.ExitPoint();
    }

    public int GetProgressPointIndex()
    {
        int count = 0;
        foreach (PuzzleProgressPoint progressPoint in puzzleProgressPoints)
        {
            if (currentPoint == puzzleProgressPoints[count])
            {
                return count;
            }
            count++;
        }
        return 0;
    }


}
