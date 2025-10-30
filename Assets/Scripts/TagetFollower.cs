using UnityEngine;
public class TagetFollower : MonoBehaviour
{ 
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Transform _target;

    private void LateUpdate()
    {
        transform.position = _target.position + _offset;
    }
}