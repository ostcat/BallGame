using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsCollector : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("����� � ���������");
        if (other.TryGetComponent(out Coin coin) == false)
            return;
        Debug.Log("��� ����� rerturn");
        _wallet.AddMoney(coin.CoinValue);
        coin.StopCoin();
    }
}
