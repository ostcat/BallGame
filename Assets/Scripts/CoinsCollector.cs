using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsCollector : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Вошли в коллайдер");
        if (other.TryGetComponent(out Coin coin) == false)
            return;
        Debug.Log("Код после rerturn");
        _wallet.AddMoney(coin.CoinValue);
        coin.StopCoin();
    }
}
