using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private Vector3 _startingPosition;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public bool IsOnTheGround {  get; private set; }

    private void OnCollisionStay(Collision collision)
    {
        Ground ground = collision.collider.GetComponent<Ground>();

        if (ground != null)
            IsOnTheGround = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        Ground ground = collision.collider.GetComponent<Ground>();

        if (ground != null)
            IsOnTheGround = false;
    }

    public void Restart()
    {
        gameObject.SetActive(true);
        _rigidbody.isKinematic = false;
        _rigidbody.position = _startingPosition;
    }

    public void Stop()
    {
        _rigidbody.isKinematic = true;
        gameObject.SetActive(false);
    }
}