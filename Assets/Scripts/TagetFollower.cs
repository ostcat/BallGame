using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TagetFollower : MonoBehaviour
{ 
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Transform _target;

    private void LateUpdate()
    {
        transform.position = _target.position + _offset;
    }
}
