using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XRCORE;

public class Level : MonoBehaviour
{
    [SerializeField] private Material levelMaterial;
    
    private GameObject _container;
    

    private void Awake()
    {
        _container = transform.GetChild(0).gameObject;
        //CombineLevelMesh();
    }

    private void CombineLevelMesh()
    {
        var level = CombineMeshes.Combine(gameObject, transform, levelMaterial);
        level.AddComponent<MeshCollider>();
        
    }

    public void Show()
    {
        _container.SetActive(true);
    }

    public void Hide()
    {
        _container.SetActive(false);
    }
}
