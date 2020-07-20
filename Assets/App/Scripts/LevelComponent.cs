using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComponent : MonoBehaviour
{
    // public event Action OnBallLeftLevel = delegate { };
    
    private void OnTriggerExit(Collider other)
    {
        // if (other.CompareTag("Particle Ball"))
        // {
        //     BallLeftLevel();
        // }
    }

    private void BallLeftLevel()
    {
        //OnBallLeftLevel();
    }
}
