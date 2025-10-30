using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _coinValue = 10;
    [SerializeField] private Wallet _wallet;

    private void OnTriggerEnter(Collider other)
    {
        Ball ball = other.GetComponent<Ball>();

        if (ball != null)
        {
            _wallet.AddMoney(_coinValue);
            gameObject.SetActive(false);
        }
    }
}
