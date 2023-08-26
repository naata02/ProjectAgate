using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoremanager : MonoBehaviour
{
    public float Score;

    public void addScore(float addition)
    {
        Score += addition;
    }

    public void ResetScore()
    {
        
    }
}
