using UnityEngine;

public class CoinsCollector : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Coin coin) == false)
            return;

        _wallet.AddMoney(coin.CoinValue);
        coin.StopCoin();
    }
}
