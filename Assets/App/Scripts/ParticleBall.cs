using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ParticleBall : MonoBehaviour
{
    public static event Action OnBallPickedUp = delegate { };
    public static event Action OnBallLeftLevel = delegate { };
    public event Action OnBallCompletedLevel = delegate { };

    
    [SerializeField] private float maxFollowSpeed;
    [SerializeField] private float exitCheckRadius;

    
    private Transform _detectedHand;
    private bool _following;
    private float _followSpeed;
    private bool _exited;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player Hand") && !_following)
        {
            //if (_following) return;
            PickUp(other.transform);
        }
        
        if (other.CompareTag("Destination"))
        {
            other.GetComponent<BallDestination>().DeactivateCollider();
            CompleteLevel();
        }
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Path"))
        {
            _exited = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Path"))
        {
            // Checks if we have truly exited any path
            if (!InsidePathObject())
            {
                _exited = true;
                OnBallLeftLevel();
            }
        }
    }

    private void Update()
    {
        if (!_following) return;
        SetSpeed();
        transform.position = Vector3.Lerp(transform.position, _detectedHand.position, Time.deltaTime * _followSpeed);
    }

    private void PickUp(Transform handObject)
    {
        _detectedHand = handObject.transform;
        _following = true;
        
        OnBallPickedUp();
    }

    private void SetSpeed()
    {
        _followSpeed = Vector3.Distance(transform.position, _detectedHand.position);
        _followSpeed = Mathf.Clamp(_followSpeed, .9F, maxFollowSpeed);
    }
    
    private bool InsidePathObject()
    {
        var colliders = Physics.OverlapSphere(transform.position, exitCheckRadius);

        return colliders.Any(c => c.gameObject.CompareTag("Path"));
    }
    
    private void CompleteLevel()
    {
        LevelHandler.Instance.NextLevel();
        OnBallCompletedLevel();
    }
}
