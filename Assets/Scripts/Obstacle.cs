using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private ParticleSystem _collisionEffect;
    [SerializeField] private float _damagePerSecond = 1;

    private float _timeBetweenDamageTicks = 0.1f;
    private float _damagePerTick;
    private float _time = 0;

    private void Awake()
    {
        _damagePerTick = _damagePerSecond * _timeBetweenDamageTicks;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        if (ball != null)
        {
            _collisionEffect.Play();
            TakeDamageTo(ball);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        ContactPoint firstContact = collision.contacts[0];

        _collisionEffect.transform.position = firstContact.point;
        _collisionEffect.transform.rotation = Quaternion.LookRotation(-firstContact.normal);

        if (ball != null)
        {
            _time += Time.deltaTime;

            if (_time > _timeBetweenDamageTicks)
            {
                TakeDamageTo(ball);
            }
        }
    }

    private void TakeDamageTo(Ball ball)
    {
        ball.TakeDamage(_damagePerTick);

        if (ball.CurrentHealth <= 0)
            _collisionEffect.Stop();

        _time = 0;
    }

    private void OnCollisionExit(Collision collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        if (ball != null)
        {
            _collisionEffect.Stop();
            _time = 0;
        }
    }
}