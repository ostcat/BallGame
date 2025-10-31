using System.Collections.Generic;
using UnityEngine;

public class CoinsHolder : MonoBehaviour
{
     public List<Coin> Coins { get; private set; }

    private void Awake()
    {
        Coins = new List<Coin>(GetComponentsInChildren<Coin>());
    }
}
