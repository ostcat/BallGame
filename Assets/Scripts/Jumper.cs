using UnityEngine;

public class Jumper : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Ball _ball;
    private KeyCode _jumpKey = KeyCode.Space;

    [SerializeField] private float _jumpForce;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _ball = GetComponent<Ball>();
    }

    private void Update()
    {
        if (_ball.IsOnTheGround == false)
            return;
       
        if (Input.GetKey(_jumpKey))
            _rigidbody.AddForce(Vector3.up * _jumpForce * Time.deltaTime, ForceMode.Impulse);
    }
}