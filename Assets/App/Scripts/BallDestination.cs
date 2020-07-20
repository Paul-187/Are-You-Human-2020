using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestination : MonoBehaviour
{
    public event Action OnBallCompletedLevel = delegate { };

    private void Awake()
    {
        
    }

    public void DeactivateCollider()
    {
        GetComponent<Collider>().enabled = false;
    }
    
    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag("Particle Ball"))
    //     {
    //         CompleteLevel();
    //     }
    // }
    //
    // private void CompleteLevel()
    // {
    //     LevelHandler.Instance.NextLevel();
    //     OnBallCompletedLevel();
    // }
}
