using UnityEngine;

public class Jumper : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Ball _ball;
    private KeyCode _jumpKey = KeyCode.Space;
    private bool _isJumping = false;

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

        if (Input.GetKeyDown(_jumpKey))
            _isJumping = true;
    }

    private void FixedUpdate()
    {
        if (_isJumping)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _isJumping = false;
        }
    }
}