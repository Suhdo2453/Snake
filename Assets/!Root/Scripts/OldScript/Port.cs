using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Port : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _collider;

    public void DisableCollider()
    {
        _collider.enabled = false;
    }
    
    public void EnableCollider()
    {
        _collider.enabled = true;
    }
}
