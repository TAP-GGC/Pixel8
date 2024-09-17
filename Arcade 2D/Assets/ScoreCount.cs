using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreCount : MonoBehaviour
{
    public UnityEvent changeScore;
   public int score { get; private set; }

    public void addScore(int count)
    {
        score += count;
        changeScore.Invoke();
    }
}
