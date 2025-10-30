using UnityEngine;

public class MoverByInput : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";
    [SerializeField] private float _force = 50;

    private Rigidbody _rigidbody;
  
    private float _deadZone = 0.05f;
    private float _xInput;
    private float _zInput;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _xInput = Input.GetAxisRaw(HorizontalAxis);
        _zInput = Input.GetAxisRaw(VerticalAxis);
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(_xInput) > _deadZone)
            _rigidbody.AddForce(Vector3.right * _force * _xInput, ForceMode.Force);

        if (Mathf.Abs(_zInput) > _deadZone)
            _rigidbody.AddForce(Vector3.forward * _force * _zInput, ForceMode.Force);
    }
}