using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int _money;
    [SerializeField] private int _coinsNumber;

    public int CoinsNumber => _coinsNumber;

    public void AddMoney(int coinValue)
    {
        _money += coinValue;
        _coinsNumber++;
    }

    public void Reset()
    {
        _money = 0;
        _coinsNumber = 0;
    }
}