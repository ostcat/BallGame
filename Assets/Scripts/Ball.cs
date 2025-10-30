using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 5;
    [SerializeField] private Vector3 _startingPosition;
    private Rigidbody _rigidbody;
    private float _currentHealth;

    public float CurrentHealth => _currentHealth;

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
        _currentHealth = _maxHealth;
    }

    public void Stop()
    {
        _rigidbody.isKinematic = true;
        gameObject.SetActive(false);
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;

        if (_currentHealth < 0)
            _currentHealth = 0;
    }
}