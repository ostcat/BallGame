using UnityEngine;

public class RotatorAroundYAxis : MonoBehaviour
{
    private int _firstSide = 1;
    private int _secondSide = -1;

    private int _currentSide;

    [SerializeField] private float _rotationSpeed = 50;

    private void Awake()
    {
        DetermineRotationSide();
    }

    private int DetermineRotationSide()
    {
        int chance = Random.Range(0, 2);
        return _currentSide = chance == 0 ? _firstSide : _secondSide;
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * _currentSide * _rotationSpeed * Time.deltaTime);
    }
}
